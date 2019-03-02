# themis

themis: a collaborative tasks/chores management tool. it can be used for household chores planning across multiple tennants.

***NOTE:*** this is a pure prototypical implementation for illustrating the general concept of themis. thus almost everything except some basic features is missing like:
- no clean code
- no localization (language is english but weekstart day is monday)
- no exception handling
- no logging
- no validation of user input

## use case example
* a group of people needs to coordinate one or more reoccuring tasks:  
> clean the floor  

* each task has a duration like:
> the floor needs to be cleaned every 2 weeks
  
* the assignee for each task switchs after a turn: 
> we take turns for floor-cleaning in this order: 1. Jon, 2. Pete, 3. Chris and then starting again at 1.

themis tries to solve the problem of tracking who's turn currently is. especially if you have a large number of tasks with many assignees (like in a family household or in a shared flat). 

this allows everyone to at least know who would be responsible for bringing the trash out.

## features
* plans with multiple tasks like the above can be configured
* themis provides an overview of:
    - who is currently assigned to which task
    - what is the first and last day of each assignment
    - who will be next
* share the plan via a link with everyone
* no account needed: data is somewhat protected by a hard to guess link to individual plans