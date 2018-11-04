# Todo Quick Stickers
<sub><sup>This section has quick todo list which is not in project issue list
 (can migrate of GitHub)</sub></sup>


## Runnable
* Runnable - consider invoking async methods and properly awaiting them - 
 this is needed for example to make sure that tests epilogue is ran to completion on 
a thread pool and properly awaited for

## WebClient vs HttpClient + async
* Revise Azos.Web.WebClient to use proper async model

## Async reflection
* ReflectionUtils -add method to test a method for being async

## Glue
* Revise Glue use of async methods in contracts
* Make CallSlot custom awaitable
* [2018-11-01]~~Glue Server call context - get rid of ThreadStatic~~

## MVC
* Bring back async pipeline in a separate branch

## Data Access
* Revise async CRUDOperationContext
* Revise MySql, Mongo and MsSql async implementation of data stores

## File System
* Revise async access functions

## General
Research and replace TaskUtils.AsCompletedTask() with Task.FromResult(t) - are they different?