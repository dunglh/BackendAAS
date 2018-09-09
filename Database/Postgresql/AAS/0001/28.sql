CREATE VIEW public."ViewModule" AS
SELECT Modu.*,
App."ApplicationCode", App."ApplicationName"
FROM public."Module" Modu
JOIN public."Application" App ON Modu."ApplicationId" = App."Id"