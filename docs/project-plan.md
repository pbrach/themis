# themis

Themis is a chores management tool. It can be used for household chores planning across multiple tennants.

## Requirements (milestone 1)

- User: wants to see an overview of all tasks and their assigment for the next 7 days
    - task name
    - description
    - timeframe
    - assigned users
- Admin: wants to create tasks
    - descrption
    - name
    - task interval
- Admin: wants to (re)assign users to tasks
- Admin: wants to create users
- User: wants to filter the overview (optional)
    - user
    - time

## Tooling

- source control: git / github
- task management: github project
- requirments management: github issues
- documentation: markdown

## Tech stack

- net core 2.2.1
- EF core (code first)
- SQLite DB
- aspnet core
- frontend 1: React
- frontentd 2: MVC core
- testing: xunit + FakeItEasy
- logging: NLog

## General

- 2 frontends (because we can)
- language: English
- no localization
- licence: gpl3

## Branches

- master: stable
- dev: integration
- feature branches: prefix `feat/`