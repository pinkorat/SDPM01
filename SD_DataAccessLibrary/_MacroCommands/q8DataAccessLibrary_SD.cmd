C:
cd \__Q1\KGRS042\Main\SDPM01\SD_DataAccessLibrary\_MacroCommands


call q1DsDbDa_SD Application NEW ApplicationID $NONE$
call q1DsDbDa_SD Calendar NEW DayDate $NONE$
call q1DsDbDa_SD ChangeRequest NEW ChangeRequestID Application
call q1DsDbDa_SD Client NEW ClientID $NONE$
call q1DsDbDa_SD Person NEW PersonID $NONE$
call q1DsDbDa_SD Project NEW ProjectID Client
call q1DsDbDa_SD RequestItem NEW RequestItemID ChangeRequest
call q1DsDbDa_SD RequestStatus NEW RequestStatusID ChangeRequest
call q1DsDbDa_SD Step NEW StepID Task
call q1DsDbDa_SD Task NEW TaskID TaskHeading
call q1DsDbDa_SD TaskChargeCode NEW Id TaskHeadingRole
call q1DsDbDa_SD TaskHeading NEW TaskHeadingID Project
call q1DsDbDa_SD TaskHeadingRole NEW Id TaskHeading
call q1DsDbDa_SD TaskRole NEW TaskRoleID $NONE$
call q1DsDbDa_SD TimeReport NEW Id Person

call q1DsDbDa_SD PickList NEW ListID $NONE$
