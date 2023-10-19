#!/bin/bash

# Defining variables
ConnectionStrings=""
GoogleClientId=""
GoogleClientSecret=""
user=""
working_dir=""


# Checking the availability of the Microsoft package
if ! dpkg -s packages-microsoft-prod &> /dev/null; then
    # Downloading and installing the Microsoft Package
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    rm packages-microsoft-prod.deb
fi

# Checking availability .NET 7.0 
if ! command -v dotnet &> /dev/null; then
    # Update and installation .NET 7.0 
    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-7.0
fi

# Output of the version .NET
dotnet --version

# Going to the TodoListApi directory
cd TodoListApi

# Restoring .NET dependencies
dotnet restore

# Setting the environment variable ASPNETCORE_URLS
export ASPNETCORE_URLS=http://localhost:5000
export Google__ClientId=$GoogleClientId
export Google__ClientSecret=$GoogleClientSecret
export ConnectionStrings__DefaultConnection=$ConnectionStrings

# Building a project
dotnet build

# Project publication
dotnet publish -c Release -o "$working_dir/web"

# Checking for Nginx
if ! command -v nginx &> /dev/null; then
    # Installing Nginx
    sudo apt-get install -y nginx

    # Adding Nginx Configuration
    sudo bash -c 'cat > /etc/nginx/sites-available/todolistapi <<EOF
server {
    listen 80 default_server deferred;
    server_name todolistapi.com;

    location / {
      proxy_pass http://127.0.0.1:5000;
      proxy_http_version 1.1;
      proxy_set_header Upgrade \$http_upgrade;
      proxy_set_header Connection keep-alive;
      proxy_set_header Host \$host;
      proxy_cache_bypass \$http_upgrade;
      proxy_set_header X-Forwarded-For \$proxy_add_x_forwarded_for;
      proxy_set_header X-Forwarded-Proto \$scheme;
    }
}
EOF'

# Checking for a symbolic link
if [ ! -e /etc/nginx/sites-enabled/todolistapi ]; then
    # Creating a symbolic link
    sudo rm /etc/nginx/sites-enabled/default
    sudo ln -s /etc/nginx/sites-available/todolistapi /etc/nginx/sites-enabled/

    # Restarting Nginx
    sudo service nginx restart
fi
fi

# Checking for the systemd service
if ! systemctl is-active --quiet todolistapi.service; then
    # Creating a systemd service file
    sudo tee /etc/systemd/system/todolistapi.service > /dev/null <<EOF
[Unit]
Description=TodoList api on linux VM

[Service]
WorkingDirectory=$working_dir/web
ExecStart=/usr/bin/dotnet $working_dir/web/TodoList.Web.dll
Restart=always
RestartSec=300
KillSignal=SIGINT
SyslogIdentifier=todolistapi-identifier
User=$user
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target
EOF
 # Activating and starting the systemd service
    sudo systemctl enable todolistapi.service
    sudo systemctl start todolistapi.service
fi

# Checking the service status
sudo systemctl status todolistapi.service

# Checking the availability of the application
curl -v http://localhost:5000
sudo systemctl status todolistapi.service