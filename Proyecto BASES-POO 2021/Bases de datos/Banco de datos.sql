

CREATE DATABASE FinalProjectPOO_DB;
USE FinalProjectPOO_DB;
SET LANGUAGE us_english;

CREATE TABLE CITIZEN
	(
		dui varchar(10) PRIMARY KEY,
		name VARCHAR (50),
		address VARCHAR (100),
		phone INT,
		email VARCHAR (40) NULL,
		birthday DATE,
		id_appointment1 INT NULL,
		id_institution INT
	);

CREATE TABLE INSTITUTION
	(
		id INT PRIMARY KEY,
		institution VARCHAR (25)
	);

CREATE TABLE DISEASE
	(
		id INT PRIMARY KEY IDENTITY,
		dui_CITIZEN INT,
		DISEASE VARCHAR (40)
	);

CREATE TABLE APPOINTMENT
	(
		id_appointment1 INT PRIMARY KEY IDENTITY,
		time_date DATETIME,
		time_date_row DATETIME NULL,
		time_date_vaccine DATETIME NULL,
		id_cabin_appointment1 INT NULL,
		id_appointment2 INT NULL,
		time_dat2 DATETIME NULL,
		time_date_row2 DATETIME NULL,
		time_date_vaccine2 DATETIME NULL,
		id_cabin_appointment2 INT NULL
	);

CREATE TABLE EFFECT_APPOINTMENT1
	(
		id INT PRIMARY KEY IDENTITY,
		id_appointment1 INT,
		id_effect_catalog INT
	);

CREATE TABLE EFFECT_APPOINTMENT2
	(
		id INT PRIMARY KEY IDENTITY,
		id_appointment2 INT,
		id_effect_catalog INT
	);

	CREATE TABLE EFFECT_CATALOG
	(
		id INT PRIMARY KEY,
		effect VARCHAR(50)
	);
	
	
CREATE TABLE CABIN
	(
		id INT PRIMARY KEY,
		id_employee_charge INT,
		phone INT,
		email VARCHAR(40),
		address VARCHAR (100)
	);

CREATE TABLE LOGS
	(
		id INT PRIMARY KEY IDENTITY,
		id_cabin INT,
		id_employee INT,
		time_date DATETIME
		
	);

CREATE TABLE EMPLOYEE
	(
		id INT PRIMARY KEY,
		nickname VARCHAR (30) NULL,
		password VARCHAR (30) NULL,
		name VARCHAR (50),
		email VARCHAR (40),
		address VARCHAR (100),
		id_type_employee INT
	);

CREATE TABLE TYPE_EMPLOYEE
	(
		id INT PRIMARY KEY,
		type VARCHAR (20)
	);

	--Foreign keys

	ALTER TABLE CITIZEN
	ADD CONSTRAINT fk_citizen_institution
	FOREIGN KEY (id_institution) REFERENCES institution (id);

	ALTER TABLE DISEASE
	ADD CONSTRAINT fk_disease_citizen
	FOREIGN KEY (dui_CITIZEN) REFERENCES CITIZEN (dui);

	ALTER TABLE CITIZEN
	ADD CONSTRAINT fk_citizen_appointment
	FOREIGN KEY (id_appointment1) REFERENCES APPOINTMENT (id_appointment1);

	ALTER TABLE EFFECT_APPOINTMENT1
	ADD CONSTRAINT fk_id_appointment1
	FOREIGN KEY (id_appointment1) REFERENCES APPOINTMENT (id_appointment1);

	ALTER TABLE EFFECT_APPOINTMENT1
	ADD CONSTRAINT fk_effect_catalog
	FOREIGN KEY (id_effect_catalog) REFERENCES EFFECT_CATALOG (id);

	ALTER TABLE EFFECT_APPOINTMENT2
	ADD CONSTRAINT fk_effect_catalog2
	FOREIGN KEY (id_effect_catalog) REFERENCES EFFECT_CATALOG (id);
	

	ALTER TABLE EFFECT_APPOINTMENT2
	ADD CONSTRAINT fk_id_appointment2
	FOREIGN KEY (id_appointment2) REFERENCES APPOINTMENT (id_appointment1);

	ALTER TABLE APPOINTMENT
	ADD CONSTRAINT fk_cabin_appointment1
	FOREIGN KEY (id_cabin_appointment1) REFERENCES CABIN (id);

	ALTER TABLE APPOINTMENT
	ADD CONSTRAINT fk_cabin_appointment2
	FOREIGN KEY (id_cabin_appointment2) REFERENCES CABIN (id);

	ALTER TABLE CABIN
	ADD CONSTRAINT fk_employee_charge
	FOREIGN KEY (id_employee_charge) REFERENCES EMPLOYEE (id);

	ALTER TABLE LOGS
	ADD CONSTRAINT fk_cabin
	FOREIGN KEY (id_cabin) REFERENCES CABIN (id);

	ALTER TABLE LOGS
	ADD CONSTRAINT fk_employee
	FOREIGN KEY (id_employee) REFERENCES EMPLOYEE (id);

	ALTER TABLE EMPLOYEE
	ADD CONSTRAINT fk_employee_TypeEmployee
	FOREIGN KEY (id_type_employee) REFERENCES TYPE_EMPLOYEE (id);

	--trigger
	CREATE TRIGGER CHECK_CABIN 
	ON CABIN
	after insert
	as begin 
		--declarando variables
		Declare @id int;
		Declare @id_employed_charged int ;
		Declare @phone int ;
		Declare @email varchar(40);
		Declare @address varchar(100);
		Declare @type int;
		-- validando datos
		select @id = id,@id_employed_charged = id_employee_charge,@phone = phone,@email = email,@address = address from inserted;
		SELECT @type = EMPLOYEE.id_type_employee FROM EMPLOYEE 
		WHERE @id_employed_charged = EMPLOYEE.id
		if 2 = @type
		begin
		RAISERROR ('ERROR: El tipo de empleado no es aceptado ',11,1);
			ROLLBACK TRANSACTION;
		end;
	end;

	-- Agregando datos necesarios
	--tipo de empleado
	INSERT INTO TYPE_EMPLOYEE (id,type)VALUES (1,'Encargado');
	INSERT INTO TYPE_EMPLOYEE (id,type)VALUES (2,'Gestor');

	--empleado
	INSERT INTO EMPLOYEE (id,name,email,address,id_type_employee)VALUES (1,'Federico','54321@gob.sv','Antiguo Cuscatlan',1);
	INSERT INTO EMPLOYEE (id,nickname,password,name,email,address,id_type_employee)VALUES (2,'78961','12345','Jose','78961@gob.sv','San Salvador',2);
	INSERT INTO EMPLOYEE (id,nickname,password,name,email,address,id_type_employee)VALUES (3,'96122','74185','Juan','96122@gob.sv','Santa Tecla',2);
	INSERT INTO EMPLOYEE (id,name,email,address,id_type_employee)VALUES (4,'Lucia','55136@gob.sv','Nuevo Cuscatlan',1);
	INSERT INTO EMPLOYEE (id,nickname,password,name,email,address,id_type_employee)VALUES (5,'89541','12386','Andrea','89541@gob.sv','Escalon',2);
	INSERT INTO EMPLOYEE (id,name,email,address,id_type_employee)VALUES (6,'Paola','69842@gob.sv','Los Proceres',1);
	
	--cabina
	INSERT INTO CABIN (id,id_employee_charge,phone,email,address)VALUES (1,1,851349734,'12345@gob.sv','Santa Tecla');
	INSERT INTO CABIN (id,id_employee_charge,phone,email,address)VALUES (2,4,597751346,'23456@gob.sv','Antiguo Cuscatlan');
	INSERT INTO CABIN (id,id_employee_charge,phone,email,address)VALUES (3,6,782741963,'34567@gob.sv','Nuevo Cuscatlan');
	--cita

	--Efectos secundarios uno

	--Efectos secundarios dos

	--Catalogo de efecto
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (1,'dolor y sensibilidad en sitio de la inyeccion');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (2,'enrojecimiento en el sitio de la inyeccion');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (3,'fatiga');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (4,'dolor de cabeza');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (5,'fiebre');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (6,'mialgia');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (7,'artralgia');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (8,'anafilaxia');
	INSERT INTO EFFECT_CATALOG (id,effect)VALUES (9,'otros');

	--Ciudadano

	--efermedad

	--institucion
	INSERT INTO INSTITUTION (id,institution)VALUES(1,'educación');
	INSERT INTO INSTITUTION (id,institution)VALUES(2,'salud');
	INSERT INTO INSTITUTION (id,institution)VALUES(3,'PNC');
	INSERT INTO INSTITUTION (id,institution)VALUES(4,'gobierno');
	INSERT INTO INSTITUTION (id,institution)VALUES(5,'fuerza armada');
	INSERT INTO INSTITUTION (id,institution)VALUES(6,'periodismo');
	INSERT INTO INSTITUTION (id,institution)VALUES(7,'cuerpos de socorro');
	INSERT INTO INSTITUTION (id,institution)VALUES(8,'personal de fronteras');
	INSERT INTO INSTITUTION (id,institution)VALUES(9,'centros penales');
	INSERT INTO INSTITUTION (id,institution)VALUES(10,'otros');

	select * from TYPE_EMPLOYEE
	select * from EMPLOYEE
	select * from CABIN
	select * from INSTITUTION
	select * from EFFECT_CATALOG