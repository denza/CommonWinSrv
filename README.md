CommonWinServ
=============

Idea behind project was to prevent having multiple windows service for the same project.

Server has 3 elements:
* Trigger - common way to start background service is to wait one of the following events:
  -time (run every 5 minutes), 
  -file/folder change( file or folder watcher for example a file is uploaded via ftp)
  -network request
* Action - Action is the part which is actually doing a job. Most of time we have similar action which we can reuse by exposing parameters and changing a configuration. Some of examples of reusable actions would be exacution of a sql code, transforming xml from one format to another using xlst, ziping files etc.
* Process is element which is used to manage action and execution order

There is a lot of place for improvement,and keep in mind it is developed a long time ago. I used this idea to develop solution which are used in real production environment, but I was not able to contriubte back to this project because it was property code.
