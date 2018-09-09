CREATE VIEW public."ViewModuleRole" AS
SELECT Moro.*,
Modu."ModuleCode",Modu."ModuleName",Modu."ApplicationId",
Ro."RoleCode",Ro."RoleName",
App."ApplicationCode", App."ApplicationName"
FROM public."ModuleRole" Moro
JOIN public."Module" Modu On Moro."ModuleId" = Modu."Id"
JOIN public."Role" Ro ON Moro."RoleId" = Ro."Id"
JOIN public."Application" App ON Modu."ApplicationId" = App."Id"