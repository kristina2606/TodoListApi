﻿namespace TodoList.Application
{
    public interface ICurrentUser
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
    }
}