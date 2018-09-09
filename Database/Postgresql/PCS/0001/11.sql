CREATE VIEW public."ViewAddress" AS
SELECT Addr.*,
Proj."ProjectCode", Proj."ProjectName",Proj."ProjectSttId",Proj."FinishTime"
FROM public."Address" Addr
JOIN public."Project" Proj ON Addr."ProjectId" = Proj."Id"