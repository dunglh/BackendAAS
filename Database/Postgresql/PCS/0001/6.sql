CREATE SEQUENCE public."AddressSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 20;

ALTER SEQUENCE public."AddressSeq"
    OWNER TO postgres;
	
	
Create Or Replace Function Address_1() Returns Trigger As $$
	Declare
		v_newVal numeric(19) := 0;
		v_time numeric(14) := 0;
	Begin
		
		Select Cast(To_Char(Current_Timestamp,'YYYYMMDDHH24MISS') As numeric) Into v_time;
		New."CreateTime" := v_time;
		New."ModifyTime" := v_time;
		New."Modifier" := New."Creator";
		If New."Id" is null or New."Id" = 0 Then
			Select NextVal('"public"."AddressSeq"') Into v_newVal;
			New."Id" := v_newVal;
		End If;
		If New."IsActive" Is Null Then
			New."IsActive" := 1;
		End If;
		Return New;
	End;
$$ LANGUAGE plpgsql;


Create Or Replace Function Address_2() Returns Trigger As $$
	Declare
		v_time numeric(14) := 0;
	Begin		
		Select Cast(To_Char(Current_Timestamp,'YYYYMMDDHH24MISS') As numeric) Into v_time;
		New."ModifyTime" := v_time;
		Return New;
	End;
$$ LANGUAGE plpgsql;


CREATE TRIGGER "Address_1"
    BEFORE INSERT
    ON public."Address"
    FOR EACH ROW
    EXECUTE PROCEDURE public.address_1();
	
	
CREATE TRIGGER "Address_2"
    BEFORE UPDATE
    ON public."Address"
    FOR EACH ROW
    EXECUTE PROCEDURE public.address_2();