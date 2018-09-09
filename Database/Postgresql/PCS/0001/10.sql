CREATE VIEW public."ViewPost" AS
SELECT Post.*,
Proj."ProjectCode", Proj."ProjectName",Proj."ProjectSttId",Proj."FinishTime",
Addr."BaseUrl", Addr."Loginname",Addr."Password",Addr."BlogId"
FROM public."Post" Post
JOIN public."Project" Proj ON Post."ProjectId" = Proj."Id"
JOIN public."Address" Addr ON Post."AddressId" = Addr."Id"
