C:
cd \__Q1\KGRS042\Main\SDPM01\SD_DataAccessLibrary\_MacroCommands

call q1DataStoreDa_SD Application  ApplicationID $NONE$
call q1DataStoreDa_SD Calendar  DayDate $NONE$
call q1DataStoreDa_SD ChangeRequest  ChangeRequestID Application
call q1DataStoreDa_SD Client  ClientID $NONE$
call q1DataStoreDa_SD Person  PersonID $NONE$
call q1DataStoreDa_SD Project  ProjectID Client
call q1DataStoreDa_SD RequestItem  RequestItemID ChangeRequest
call q1DataStoreDa_SD RequestStatus  RequestStatusID ChangeRequest
call q1DataStoreDa_SD Step  StepID Task
call q1DataStoreDa_SD Task  TaskID TaskHeading
call q1DataStoreDa_SD TaskChargeCode  Id TaskHeadingRole
call q1DataStoreDa_SD TaskHeading  TaskHeadingID Project
call q1DataStoreDa_SD TaskHeadingRole  Id TaskHeading
call q1DataStoreDa_SD TaskRole  TaskRoleID $NONE$
call q1DataStoreDa_SD TimeReport  Id Person

