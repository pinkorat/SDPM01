    SETLOCAL
    ECHO ON

    SET p1=%1%
    SET ASLGEN_KEYFIELD=%2
    SET ASLGEN_PARENTREF=%3

	SET GEN=C:\__Q1\KGRS042\Main\_Library\ASLGEN_CodeGEN

:DO_NEWDAL
    %GEN% NEW SD %p1% _DataStoreDa
    GOTO DO_REST

:DO_REST
    ENDLOCAL

:EXIT
