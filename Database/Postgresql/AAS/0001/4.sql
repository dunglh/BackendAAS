CREATE TRIGGER "Application_1"
    BEFORE INSERT
    ON public."Application"
    FOR EACH ROW
    EXECUTE PROCEDURE public.application_1();