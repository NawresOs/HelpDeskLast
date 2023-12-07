# HelpDesk Application

Un HelpDesk, également connu sous le nom de support informatique, est un centre de service dédié à résoudre les problèmes matériels et logiciels des utilisateurs. L'objectif principal est de faciliter la gestion du parc informatique d'une entreprise en assurant une continuité d'exploitation maximale.

Ce projet vise à développer une application Web HelpDesk permettant aux utilisateurs de soumettre des réclamations et aux techniciens de les traiter.

# Functionalities
# User
+ CRUD (Create, Read, Update, Delete) operations for claims:
+ Creation of new claims with unique codes, describing the nature of the issue.
+ Tracking the status of the claim (e.g., pending, in progress, resolved, unresolved).
+ Editing or deleting claims only if the status is 'pending'. Once processed, only approval or disapproval is allowed.
+ Approval/disapproval of processed claims.
# Technician
+ View and filter claims by user and status.
+ Update claim status (e.g., in progress, problem solved).
+ Record corrective actions taken (e.g., hardware repair, software installation, on-site visit, remote computer check).
+ Close approved claims.
+ Assessment Details

# Technologies Used
+ ASP.NET Core 6.0 with MVC pattern
+ C# language
+ Entity Framework
+ SQL Server as the database management system (SGBD)
