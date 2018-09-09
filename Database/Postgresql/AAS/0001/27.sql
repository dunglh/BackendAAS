
	
CREATE VIEW public."ViewApplicationRole" AS
SELECT Apro.*,
App."ApplicationCode", App."ApplicationName",
Ro."RoleCode", Ro."RoleName"
FROM public."ApplicationRole" Apro
JOIN public."Application" App ON Apro."ApplicationId" = App."Id"
JOIN public."Role" Ro ON Apro."RoleId" = Ro."Id"