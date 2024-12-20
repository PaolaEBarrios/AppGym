
CREATE DATABASE APPGYMFINAL; 

GO 

USE APPGYMFINAL; 

  
CREATE TABLE MEMBRESIA( 

MEMBRESIAID INT PRIMARY KEY IDENTITY(1,1), 

TipoMembresia nvarchar(10), --MENSUAL O CLASE 

Valor money, -- el valor es asignado por el administrador solo para mensual 

Incluye BIT, --si es 1 es que es libre sino no 

); 
  

CREATE TABLE TipoUser( 

TipoId INT PRIMARY KEY IDENTITY(1,1), 

Tipo NVARCHAR(15), 

  

--poner permisos?? 

); 

  Create table salones (
	salonid int primary key,
	nombresalon varchar(255)
  
  )

CREATE TABLE Users ( 

    UserId INT PRIMARY KEY IDENTITY(1,1), 

    Username NVARCHAR(50) NOT NULL UNIQUE, 

    Pass NVARCHAR(256) NOT NULL, 

	DNI Nvarchar(15) not null unique,

    Tipo INT FOREIGN KEY REFERENCES TipoUser(TipoId), --ADMIN, INSTRUCTOR, Y CLIENTE 

    Email NVARCHAR(100), 

    Phone NVARCHAR(20), 

    Estado BIT,
	
); 

  

CREATE TABLE CLIENTES( 

ClientesId Int Primary key identity(1,1), 

Nombre Nvarchar(100), 

Apellido Nvarchar(100), 

Observacion Nvarchar(200), 

DNI NVARCHAR(16), 

UserId int foreign key references Users(Userid), 

IDMEMBRESIA INT FOREIGN KEY REFERENCES MEMBRESIA(MEMBRESIAID),

 Estado bit  null

); 

  

CREATE TABLE Instructors ( 

    InstructorId INT PRIMARY KEY IDENTITY(1,1), 

    UserId INT  NULL, 

    Nombre NVARCHAR(100), 

	Apellido NVARCHAR(100), 

	Detalles NVARCHAR(200), 
	DNI nvarchar(15) not null unique,
	estado bit null,
	fechaAlta datetime null,
	fechaBaja datetime null,
    FOREIGN KEY (UserId) REFERENCES Users(UserId) 

); 

  

CREATE TABLE Classes ( 

    ClaseId INT PRIMARY KEY IDENTITY(1,1), 

    ClaseName NVARCHAR(100) NOT NULL, 

    InstructorId INT NOT NULL, 

    Inscriptos tinyint null,

	Capacidad INT, 

	Detalle nvarchar(200),

	estado bit,
    FOREIGN KEY (InstructorId) REFERENCES Users(UserId) 

); 

 Create table diasHorarios(
	diadelasemana nvarchar(20) primary key,
	horarioInicio time,
	horariofin time
 
 )

CREATE TABLE DiasClases ( 

    ClaseDayId INT PRIMARY KEY IDENTITY(1,1), 

    ClaseId INT NOT NULL, 

    DayOfWeek NVARCHAR(20) NOT NULL,  

    Inicio TIME NOT NULL, -- inicio de la clase en este día 

    Fin TIME NOT NULL, -- fin de la clase en este día 
	salonid int foreign key references salones(salonid),
	instructorId int foreign key references Instructors(instructorid),

    FOREIGN KEY (ClaseId) REFERENCES Classes(ClaseId) 

); 

  

CREATE TABLE Reservaciones ( 

    ReservacionId INT PRIMARY KEY IDENTITY(1,1), 

    ClienteId INT NOT NULL, 

    ClaseId INT NOT NULL, 

    ClaseName nvarchar(100),
	dia nvarchar(20),
	horainico time,
	horafin time,
	Clasenombre varchar(20),
    Estado BIT NOT NULL, 

    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClientesId), 

    FOREIGN KEY (ClaseId) REFERENCES Classes(ClaseId) 

); 

  


  

CREATE TABLE VALOR_CLASES 

( 

ClaseId int foreign key references classes(claseid), 

Valor money, -- el valor es asignado por el administrador  

Primary key (ClaseId) 

) 


