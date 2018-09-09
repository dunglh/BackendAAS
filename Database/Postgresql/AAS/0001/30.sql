CREATE VIEW public."ViewUserRole" AS
SELECT Usro.*,
U."Loginname",U."Username",U."Email",U."Mobile",
Ro."RoleCode",Ro."RoleName"
FROM public."UserRole" Usro
JOIN public."User" U On Usro."UserId" = U."Id"
JOIN public."Role" Ro ON Usro."RoleId" = Ro."Id"