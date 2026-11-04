/********************* ROLES **********************/

CREATE ROLE RDB$ADMIN;
/********************* UDFS ***********************/

/****************** GENERATORS ********************/

/******************** DOMAINS *********************/

/******************* PROCEDURES ******************/

/******************** TABLES **********************/

CREATE TABLE ACTIVOS24
(
  CLAVE Varchar(16) NOT NULL,
  TIPO Smallint,
  DESCRIP Varchar(30) NOT NULL,
  LOCALIZ Varchar(9),
  MONTORIG Double precision,
  MONTORIGEX Double precision,
  FECHAADQ Timestamp,
  MAXDED Double precision,
  VALMER Double precision,
  DEPACU Double precision,
  VIDAUT Double precision,
  METDEP Varchar(1),
  TASDEP Double precision,
  TASDEPFIS Double precision,
  STATUS Varchar(1),
  FECHAELIM Timestamp,
  NUMDEPTO Smallint,
  FECHAULTRE Timestamp,
  NUMSERIE Varchar(24),
  BANDEDINM Varchar(1),
  FECINIDEP Timestamp,
  FECINIDEPF Timestamp,
  DEPACUFISC Double precision,
  OBSERVACIO Varchar(250),
  TIPOCAMBIO Double precision,
  POLIZASEG Varchar(20),
  COMPASEGU Varchar(40),
  AGENTESEG Varchar(40),
  TELSINIES Varchar(15),
  TIPOCOBER Varchar(20),
  MONTOASEG Double precision,
  PRIMATOTA Double precision,
  DEDUCIBLE Double precision,
  FECVIGENC Timestamp,
  FECPROXMA Timestamp,
  FECULTMAN Timestamp,
  PERIODOMA Smallint,
  COSTOMANT Double precision,
  RESPACTFIJO Varchar(60),
  CONSTRAINT PK_ACTIVOS24 PRIMARY KEY (CLAVE)
);
CREATE TABLE ACTIVOS25
(
  CLAVE Varchar(16) NOT NULL,
  TIPO Smallint,
  DESCRIP Varchar(30) NOT NULL,
  LOCALIZ Varchar(9),
  MONTORIG Double precision,
  MONTORIGEX Double precision,
  FECHAADQ Timestamp,
  MAXDED Double precision,
  VALMER Double precision,
  DEPACU Double precision,
  VIDAUT Double precision,
  METDEP Varchar(1),
  TASDEP Double precision,
  TASDEPFIS Double precision,
  STATUS Varchar(1),
  FECHAELIM Timestamp,
  NUMDEPTO Smallint,
  FECHAULTRE Timestamp,
  NUMSERIE Varchar(24),
  BANDEDINM Varchar(1),
  FECINIDEP Timestamp,
  FECINIDEPF Timestamp,
  DEPACUFISC Double precision,
  OBSERVACIO Varchar(250),
  TIPOCAMBIO Double precision,
  POLIZASEG Varchar(20),
  COMPASEGU Varchar(40),
  AGENTESEG Varchar(40),
  TELSINIES Varchar(15),
  TIPOCOBER Varchar(20),
  MONTOASEG Double precision,
  PRIMATOTA Double precision,
  DEDUCIBLE Double precision,
  FECVIGENC Timestamp,
  FECPROXMA Timestamp,
  FECULTMAN Timestamp,
  PERIODOMA Smallint,
  COSTOMANT Double precision,
  RESPACTFIJO Varchar(60),
  CONSTRAINT PK_ACTIVOS25 PRIMARY KEY (CLAVE)
);
CREATE TABLE ADMPER
(
  PERIODO Smallint NOT NULL,
  EJERCICIO Smallint NOT NULL,
  CERRADO Smallint,
  ORDENADO Integer,
  REQTRASP Smallint,
  CTPOLIZAS Integer,
  CONSTRAINT PK_ADMPER PRIMARY KEY (PERIODO,EJERCICIO)
);
CREATE TABLE AUXILIAR24
(
  TIPO_POLI Varchar(2) NOT NULL,
  NUM_POLIZ Varchar(5) NOT NULL,
  NUM_PART Double precision NOT NULL,
  PERIODO Smallint NOT NULL,
  EJERCICIO Smallint NOT NULL,
  NUM_CTA Varchar(21),
  FECHA_POL Timestamp,
  CONCEP_PO Varchar(120),
  DEBE_HABER Varchar(1),
  MONTOMOV Double precision,
  NUMDEPTO Smallint,
  TIPCAMBIO Double precision,
  CONTRAPAR Smallint,
  ORDEN Integer,
  CCOSTOS Integer,
  CGRUPOS Integer,
  IDINFADIPAR Integer DEFAULT -1,
  IDUUID Integer DEFAULT -1,
  CONSTRAINT PK_AUXILIAR24 PRIMARY KEY (TIPO_POLI,NUM_POLIZ,NUM_PART,PERIODO,EJERCICIO)
);
CREATE TABLE AUXILIAR25
(
  TIPO_POLI Varchar(2) NOT NULL,
  NUM_POLIZ Varchar(5) NOT NULL,
  NUM_PART Double precision NOT NULL,
  PERIODO Smallint NOT NULL,
  EJERCICIO Smallint NOT NULL,
  NUM_CTA Varchar(21),
  FECHA_POL Timestamp,
  CONCEP_PO Varchar(120),
  DEBE_HABER Varchar(1),
  MONTOMOV Double precision,
  NUMDEPTO Smallint,
  TIPCAMBIO Double precision,
  CONTRAPAR Smallint,
  ORDEN Integer,
  CCOSTOS Integer,
  CGRUPOS Integer,
  IDINFADIPAR Integer DEFAULT -1,
  IDUUID Integer DEFAULT -1,
  CONSTRAINT PK_AUXILIAR25 PRIMARY KEY (TIPO_POLI,NUM_POLIZ,NUM_PART,PERIODO,EJERCICIO)
);
CREATE TABLE CCOSTOS
(
  ID Integer NOT NULL,
  DESCRIPCION Varchar(40),
  CONSTRAINT PK_CCOSTOS PRIMARY KEY (ID)
);
CREATE TABLE CGRUPOS
(
  ID Integer NOT NULL,
  DESCRIPCION Varchar(40),
  CONSTRAINT PK_CGRUPOS PRIMARY KEY (ID)
);
CREATE TABLE COMPLEMENTOSPAGOS
(
  UUIDTIMBREPAGO Varchar(36) NOT NULL,
  SERIE Varchar(25),
  FOLIO Varchar(40),
  FECHA Timestamp,
  RFCEMISOR Varchar(36),
  NOMBREEMISOR Varchar(300),
  MONTO Double precision,
  TIPO_POLI Varchar(2),
  NUM_POLIZ Varchar(5),
  PERIODO Smallint,
  EJERCICIO Smallint,
  RUTAXML Varchar(512),
  XML Blob sub_type 1,
  CONSTRAINT PK_COMPLEMENTOSPAGOS PRIMARY KEY (UUIDTIMBREPAGO)
);
CREATE TABLE CONCEPTO
(
  CONCEPTO Integer NOT NULL,
  DESCRIP Varchar(120),
  CONSTRAINT PK_CONCEPTO PRIMARY KEY (CONCEPTO)
);
CREATE TABLE CONTROL
(
  CTCONCEPTOS Integer,
  CTDEPTOS Integer,
  CTMONEDAS Integer,
  CTRANGOS Integer,
  CTTIPACTIV Integer,
  CTREGPOL Integer,
  VERBASDAT Integer,
  CCOSTOS Integer,
  CGRUPOS Integer,
  CTCONCIETU Integer,
  CTCONCIVAT Integer,
  CTCONCIVAA Integer,
  CTINFADIPAR Integer,
  CTUUIDCOMP Integer,
  CTIDOTROSIMP Integer,
  CTIDOTROSIMPING Integer,
  ULTIMADESC_LISTANEGRA Timestamp,
  CTUNIF Integer,
  CTUEDOFINNIF Integer
);
CREATE TABLE CTAING
(
  CUENTA Varchar(21) NOT NULL,
  TIPO Varchar(1),
  RFCIDFISC Varchar(40),
  IVADEFAULT Double precision,
  PORCENTAJEIVA Double precision,
  PORCENTAJEISR Double precision,
  INCLUYEIVA Smallint,
  IDCONCEP Integer,
  IDCONCEPIVAT Integer,
  CONSTRAINT PK_CTAING PRIMARY KEY (CUENTA)
);
CREATE TABLE CTANIF
(
  ID_NIF Integer NOT NULL,
  CUENTA Varchar(21) NOT NULL,
  CONSTRAINT PK_CTANIF PRIMARY KEY (ID_NIF,CUENTA)
);
CREATE TABLE CTARUB
(
  RUBRO Integer NOT NULL,
  CUENTA Varchar(21) NOT NULL,
  SEGPAPA Varchar(21),
  CONSTRAINT PK_CTARUB PRIMARY KEY (RUBRO,CUENTA)
);
CREATE TABLE CTAS_PRODSERV
(
  CVE_PRODSERV Varchar(8) NOT NULL,
  NUM_CTA_VENTA Varchar(21),
  NUM_CTA_COMPRA Varchar(21),
  CONSTRAINT PK_CTAS_PRODSERV PRIMARY KEY (CVE_PRODSERV)
);
CREATE TABLE CTATER
(
  CUENTA Varchar(21) NOT NULL,
  TIPO Varchar(1),
  RFCIDFISC Varchar(40),
  IVADEFAULT Double precision,
  PORCENTAJEIVA Double precision,
  PORCENTAJEISR Double precision,
  INCLUYEIVA Smallint,
  IDCONCEP Integer,
  IDCONCEPIVAA Integer,
  CONSTRAINT PK_CTATER PRIMARY KEY (CUENTA)
);
CREATE TABLE CUENTAS24
(
  NUM_CTA Varchar(21) NOT NULL,
  STATUS Varchar(1),
  TIPO Varchar(1),
  NOMBRE Varchar(40),
  DEPTSINO Varchar(1),
  BANDMULTI Smallint,
  BANDAJT Varchar(1),
  CTA_PAPA Varchar(21),
  CTA_RAIZ Varchar(21),
  NIVEL Smallint,
  CTA_COMP Varchar(21),
  NATURALEZA Smallint,
  RFC Varchar(30),
  CODAGRUP Varchar(10),
  CAPTURACHEQUE Smallint,
  CAPTURAUUID Smallint,
  BANCO Integer DEFAULT 0,
  CTABANCARIA Varchar(50),
  CAPCHEQTIPOMOV Varchar(1),
  NOINCLUIRXML Integer DEFAULT 0,
  IDFISCAL Varchar(40),
  ESFLUJODEEFECTIVO Smallint,
  BANCOEXTRANJERO Varchar(225),
  RFCFLUJO Varchar(15),
  CONSTRAINT PK_CUENTAS24 PRIMARY KEY (NUM_CTA)
);
CREATE TABLE CUENTAS25
(
  NUM_CTA Varchar(21) NOT NULL,
  STATUS Varchar(1),
  TIPO Varchar(1),
  NOMBRE Varchar(40),
  DEPTSINO Varchar(1),
  BANDMULTI Smallint,
  BANDAJT Varchar(1),
  CTA_PAPA Varchar(21),
  CTA_RAIZ Varchar(21),
  NIVEL Smallint,
  CTA_COMP Varchar(21),
  NATURALEZA Smallint,
  RFC Varchar(30),
  CODAGRUP Varchar(10),
  CAPTURACHEQUE Smallint,
  CAPTURAUUID Smallint,
  BANCO Integer DEFAULT 0,
  CTABANCARIA Varchar(50),
  CAPCHEQTIPOMOV Varchar(1),
  NOINCLUIRXML Integer DEFAULT 0,
  IDFISCAL Varchar(40),
  ESFLUJODEEFECTIVO Smallint,
  BANCOEXTRANJERO Varchar(225),
  RFCFLUJO Varchar(15),
  CONSTRAINT PK_CUENTAS25 PRIMARY KEY (NUM_CTA)
);
CREATE TABLE DEPTOS
(
  DEPTO Smallint NOT NULL,
  DESCRIP Varchar(40),
  CONSTRAINT PK_DEPTOS PRIMARY KEY (DEPTO)
);
CREATE TABLE DESIET
(
  TIPOPOL Varchar(2) NOT NULL,
  NUMPOL Varchar(5) NOT NULL,
  FECHAPOL Timestamp NOT NULL,
  NUMPART Integer NOT NULL,
  INDICE Integer NOT NULL,
  MONTO Double precision,
  CUENTAGAS Varchar(21),
  MONTODED Double precision,
  PORCDED Double precision,
  IDCONCEP Integer,
  CONSTRAINT PK_DESIET PRIMARY KEY (TIPOPOL,NUMPOL,FECHAPOL,NUMPART,INDICE)
);
CREATE TABLE DIARIOSAE
(
  FECHA_SINC Timestamp NOT NULL,
  ORIGEN Varchar(10),
  TIPO_DOC Varchar(2),
  FECHA_DOCTO Timestamp,
  ESTATUS Varchar(1),
  REFERENCIA Varchar(20),
  XML Blob sub_type 1,
  CONTABILIZ Varchar(1),
  FECHA_CONTA Timestamp,
  POLIZA Varchar(7),
  PERIODO Smallint,
  EJERCICIO Integer,
  OBS Varchar(100),
  UUID_SINC Varchar(36) NOT NULL,
  UUID_XML Varchar(36),
  RAZONSOCIAL Varchar(254),
  CONSTRAINT PK_DIARIOSAE PRIMARY KEY (UUID_SINC)
);
CREATE TABLE DOCTOSAE
(
  TIPO_DOC Varchar(2) NOT NULL,
  DOCTO Varchar(120) NOT NULL,
  PLANTILLA Varchar(512),
  CONSTRAINT PK_DOCTOSAE PRIMARY KEY (TIPO_DOC)
);
CREATE TABLE DOCTOSFISCALES
(
  UUIDTIMBRECFDI Varchar(36) NOT NULL,
  RUTAARCHIVO Varchar(512),
  TOTAL Double precision NOT NULL,
  SUBTOTAL Double precision NOT NULL,
  RFCEMISOR Varchar(36) NOT NULL,
  RFCRECEPTOR Varchar(36) NOT NULL,
  FECHAEMISION Timestamp NOT NULL,
  SERIE Varchar(100),
  FOLIO Varchar(100),
  VERSIONCFDI Varchar(6) NOT NULL,
  LUGAREXPEDICION Varchar(50) NOT NULL,
  MONEDA Varchar(3) NOT NULL,
  NUMCTAPAGO Varchar(50),
  TIPOCAMBIO Double precision,
  DESCUENTO Double precision,
  FORMAPAGO Varchar(50),
  METODOPAGO Varchar(3),
  TOTALIMPUESTOSTRASLADADOS Double precision,
  TOTALIMPUESTOSRETENIDOS Double precision,
  NOMBREEMISOR Varchar(50),
  NOMBRERECEPTOR Varchar(50),
  REGIMENFISCAL Varchar(30) NOT NULL,
  USOCFDI Varchar(6),
  SELLOCFDI Varchar(100) NOT NULL,
  NOCERTIFICADO Varchar(100) NOT NULL,
  NOCERTIFICADOTIMBRE Varchar(100) NOT NULL,
  CONDICIONESDEPAGO Varchar(50),
  SELLO Varchar(100) NOT NULL,
  TIPODECOMPROBANTE Varchar(50) NOT NULL,
  XML Blob sub_type 1,
  CONSTRAINT PK_DOCTOSFISCALES PRIMARY KEY (UUIDTIMBRECFDI)
);
CREATE TABLE DOCTOSRELPAGOS
(
  UUIDTIMBRECFDI Varchar(36) NOT NULL,
  UUIDTIMBREPAGO Varchar(36) NOT NULL,
  IDPAGO Integer NOT NULL,
  SERIE Varchar(25),
  FOLIO Varchar(40),
  MONEDADR Varchar(50),
  TIPOCAMBIODR Double precision,
  METODODEPAGODR Varchar(50),
  NUMPARCIALIDAD Integer,
  IMPSALDOANT Double precision,
  IMPPAGADO Double precision,
  IMPSALDOINSOLUTO Double precision,
  CONSTRAINT PK_DOCTOSRELPAGOS PRIMARY KEY (UUIDTIMBRECFDI,UUIDTIMBREPAGO)
);
CREATE TABLE EDOFINNIFS
(
  ID_EDO Integer NOT NULL,
  NOMBRE Varchar(100),
  ID_NIF Integer NOT NULL,
  CONSTRAINT PK_EDOFINNIFS PRIMARY KEY (ID_EDO,ID_NIF)
);
CREATE TABLE ETIQ_CCOSTOS_SIGO
(
  ETIQUETA Varchar(20) NOT NULL,
  DESCRIPCION Varchar(70),
  CCOSTOS_COI Integer,
  CONSTRAINT PK_ETIQ_CCOSTOS_SIGO PRIMARY KEY (ETIQUETA)
);
CREATE TABLE ETIQ_CTAS_POLDINAMICA
(
  ETIQUETA Varchar(20) NOT NULL,
  DESCRIPCION Varchar(70),
  CUENTA_COI Varchar(21),
  ORIGEN Integer,
  CONSTRAINT PK_ETIQ_CTAS_POLDINAMICA PRIMARY KEY (ETIQUETA)
);
CREATE TABLE ETIQ_CTAS_SIGO
(
  ETIQUETA Varchar(20) NOT NULL,
  OPERACION Varchar(100),
  DESCRIPCION Varchar(70),
  CUENTA_COI Varchar(21),
  CONSTRAINT PK_ETIQ_CTAS_SIGO PRIMARY KEY (ETIQUETA)
);
CREATE TABLE ETIQ_OPERACION_SIGO
(
  ETIQUETA Varchar(20) NOT NULL,
  OPERACION Varchar(100),
  CONSTRAINT PK_ETIQ_OPERACION_SIGO PRIMARY KEY (ETIQUETA)
);
CREATE TABLE FOLIOS
(
  TIPPOL Varchar(2) NOT NULL,
  EJERCICIO Smallint NOT NULL,
  FOLIO01 Varchar(5) DEFAULT '0',
  FOLIO02 Varchar(5) DEFAULT '0',
  FOLIO03 Varchar(5) DEFAULT '0',
  FOLIO04 Varchar(5) DEFAULT '0',
  FOLIO05 Varchar(5) DEFAULT '0',
  FOLIO06 Varchar(5) DEFAULT '0',
  FOLIO07 Varchar(5) DEFAULT '0',
  FOLIO08 Varchar(5) DEFAULT '0',
  FOLIO09 Varchar(5) DEFAULT '0',
  FOLIO10 Varchar(5) DEFAULT '0',
  FOLIO11 Varchar(5) DEFAULT '0',
  FOLIO12 Varchar(5) DEFAULT '0',
  FOLIO13 Varchar(5) DEFAULT '0',
  ASIG01 Smallint DEFAULT 0,
  ASIG02 Smallint DEFAULT 0,
  ASIG03 Smallint DEFAULT 0,
  ASIG04 Smallint DEFAULT 0,
  ASIG05 Smallint DEFAULT 0,
  ASIG06 Smallint DEFAULT 0,
  ASIG07 Smallint DEFAULT 0,
  ASIG08 Smallint DEFAULT 0,
  ASIG09 Smallint DEFAULT 0,
  ASIG10 Smallint DEFAULT 0,
  ASIG11 Smallint DEFAULT 0,
  ASIG12 Smallint DEFAULT 0,
  ASIG13 Smallint DEFAULT 0,
  ASIG14 Smallint DEFAULT 0,
  FOLIO14 Varchar(7) DEFAULT '0',
  CONSTRAINT PK_FOLIOS PRIMARY KEY (TIPPOL,EJERCICIO)
);
CREATE TABLE HISTOR
(
  MONEDA Integer,
  FECHA Timestamp,
  TIPCAMBIO Double precision
);
CREATE TABLE HOJAS
(
  TITULO Varchar(50),
  HOJAXLS Varchar(250),
  TIPOHOJA Varchar(15)
);
CREATE TABLE IMPUESTOSFISCALES
(
  NUMIMPUESTO Integer NOT NULL,
  UUIDTIMBRECFDI Varchar(36) NOT NULL,
  IMPUESTO Varchar(3),
  TIPOIMPUESTO Integer,
  ESLOCAL Integer,
  BASE Double precision,
  TIPOFACTOR Varchar(6),
  TASACUOTA Double precision,
  IMPORTE Double precision,
  CONSTRAINT PK_IMPUESTOSFISCALES PRIMARY KEY (NUMIMPUESTO,UUIDTIMBRECFDI)
);
CREATE TABLE INFADIPAR
(
  NUMREG Integer NOT NULL,
  FRMPAGO Varchar(5),
  NUMCHEQUE Varchar(20),
  BANCO Integer NOT NULL,
  CTAORIG Varchar(50),
  FECHA Timestamp NOT NULL,
  MONTO Double precision,
  BENEF Varchar(300),
  RFC Varchar(30),
  BANCODEST Integer NOT NULL,
  CTADEST Varchar(50),
  BANCOORIGEXT Varchar(225),
  BANCODESTEXT Varchar(225),
  IDFISCAL Varchar(40),
  CONSTRAINT PK_INFADIPAR PRIMARY KEY (NUMREG)
);
CREATE TABLE INFOSAE
(
  CLAVE Varchar(16) NOT NULL,
  DESCRIP Varchar(1000),
  NUM_CTA_VENTA Varchar(21),
  NUM_CTA_COMPRA Varchar(21),
  TIPO_REGISTRO Varchar(2),
  FECHA_SINC Timestamp NOT NULL,
  UUID_SINC Varchar(36) NOT NULL,
  CONSTRAINT PK_INFOSAE PRIMARY KEY (UUID_SINC)
);
CREATE TABLE INPC
(
  EJERCICIO Smallint NOT NULL,
  MES1 Double precision,
  MES2 Double precision,
  MES3 Double precision,
  MES4 Double precision,
  MES5 Double precision,
  MES6 Double precision,
  MES7 Double precision,
  MES8 Double precision,
  MES9 Double precision,
  MES10 Double precision,
  MES11 Double precision,
  MES12 Double precision,
  CONSTRAINT PK_INPC PRIMARY KEY (EJERCICIO)
);
CREATE TABLE LISTANEGRARFC
(
  RFC Varchar(15) NOT NULL,
  SITUACIONCONTRIBUYENTE Varchar(25),
  PBPAGSAT Timestamp,
  CONSTRAINT PK_LISTANEGRARFC PRIMARY KEY (RFC)
);
CREATE TABLE MONEDAS
(
  MONEDA Smallint NOT NULL,
  NOMBRE Varchar(20),
  PREFIJO Varchar(4),
  FECHA Timestamp,
  TIPOCAMBIO Double precision,
  MONTO Double precision,
  DESPAUTO Varchar(1),
  CLASSAT Varchar(3),
  CONSTRAINT PK_MONEDAS PRIMARY KEY (MONEDA)
);
CREATE TABLE NIFS
(
  ID_NIF Integer NOT NULL,
  ID_PADRE Integer NOT NULL,
  DESCRIPCION Varchar(200),
  NIVEL Integer,
  NOTAFINNIF Varchar(500),
  ID_RAIZ Integer,
  CONSTRAINT PK_NIFS PRIMARY KEY (ID_NIF)
);
CREATE TABLE OPEIET
(
  TIPOPOL Varchar(2) NOT NULL,
  NUMPOL Varchar(5) NOT NULL,
  FECHAPOL Timestamp NOT NULL,
  NUMPART Integer NOT NULL,
  NUMCTA Varchar(21),
  RFCPROVE Varchar(40),
  TIPOPE Integer,
  MONCONIVA Double precision,
  MONDEDISR Double precision,
  ACTOS15 Double precision,
  IVAOP15 Double precision,
  ACTOS10 Double precision,
  IVAOP10 Double precision,
  ACTOSCERO Double precision,
  ACTOSEXENT Double precision,
  IVARETENID Double precision,
  IVATRASLAD Double precision,
  IVADEVOLU Double precision,
  PERCAUSAC Timestamp,
  IVANOAC15 Double precision,
  IVANOAC10 Double precision,
  ESIMPORTA Varchar(1),
  OTRASRET Double precision,
  ESDEVOL Integer,
  ISRRETENID Double precision,
  IVAGENERAL Integer,
  IVAFRONTERIZO Integer,
  IDCONCEP Integer,
  INGREXENTO Double precision,
  IDCONCEPIVAT Integer,
  IDOPEIET Integer,
  CONSTRAINT PK_OPEIET PRIMARY KEY (TIPOPOL,NUMPOL,FECHAPOL,NUMPART)
);
CREATE TABLE OPETER
(
  TIPOPOL Varchar(2) NOT NULL,
  NUMPOL Varchar(5) NOT NULL,
  FECHAPOL Timestamp NOT NULL,
  NUMPART Integer NOT NULL,
  NUMCTA Varchar(21),
  RFCPROVE Varchar(40),
  TIPOPE Integer,
  MONCONIVA Double precision,
  MONDEDISR Double precision,
  ACTOS15 Double precision,
  IVAOP15 Double precision,
  ACTOS10 Double precision,
  IVAOP10 Double precision,
  ACTOSCERO Double precision,
  ACTOSEXENT Double precision,
  IVARETENID Double precision,
  IVATRASLAD Double precision,
  IVADEVOLU Double precision,
  PERCAUSAC Timestamp,
  IVANOAC15 Double precision,
  IVANOAC10 Double precision,
  ESIMPORTA Varchar(1),
  OTRASRET Double precision,
  ESDEVOL Integer,
  ISRRETENID Double precision,
  IVAGENERAL Integer,
  IVAFRONTERIZO Integer,
  IDCONCEPIVAA Integer,
  DESDECFDI Smallint,
  IDOPTER Integer,
  IMPORTEIVANOREQ8 Double precision,
  IMPORTEIVANOREQ16_GENERAL Double precision,
  UUID_XML Varchar(36),
  TIPOIMPORTACION Integer,
  ZONAFRONTERIZA Integer,
  IVANOAC_EXENTO8 Double precision,
  IVANOAC_NOOBJETO8 Double precision,
  IVANOAC_EXENTO16 Double precision,
  IVANOAC_NOOBJETO16 Double precision,
  NOOBJETO_IVANAC Double precision,
  NOOBJETO_IVASINNAC Double precision,
  PROPORCIONIVA Double precision,
  IVAAC_PROPORCION8 Double precision,
  IVAAC_PROPORCION16 Double precision,
  ACTOSNOAC8 Double precision,
  ACTOSNOAC16 Double precision,
  CONSTRAINT PK_OPETER PRIMARY KEY (TIPOPOL,NUMPOL,FECHAPOL,NUMPART)
);
CREATE TABLE OTROSIMPUESTOS
(
  IDOPTER Integer NOT NULL,
  NUMREG Integer NOT NULL,
  NOMBRE Varchar(120) NOT NULL,
  TASA Double precision,
  MONTO Double precision,
  TIPO Smallint NOT NULL,
  BASE Double precision,
  TIPOIMPUESTO Smallint NOT NULL,
  APLICADIOT Smallint,
  TIPOFACTOR Varchar(6) NOT NULL,
  PROPORCIONIVA Double precision,
  IVAAC_PROPORCION Double precision,
  IVANOAC_PROPORCION Double precision,
  CONSTRAINT PK_OTROSIMPUESTOS PRIMARY KEY (IDOPTER,TIPOIMPUESTO,TIPO,NUMREG)
);
CREATE TABLE OTROSIMPUESTOSING
(
  IDOPEIET Integer NOT NULL,
  NUMREG Integer NOT NULL,
  NOMBRE Varchar(120) NOT NULL,
  TASA Double precision,
  MONTO Double precision,
  TIPO Smallint NOT NULL,
  BASE Double precision,
  TIPOIMPUESTO Smallint NOT NULL,
  APLICAIC Smallint,
  TIPOFACTOR Varchar(6) NOT NULL,
  CONSTRAINT PK_OTROSIMPUESTOSING PRIMARY KEY (IDOPEIET,TIPOIMPUESTO,TIPO,NUMREG)
);
CREATE TABLE PAGO
(
  IDPAGO Integer NOT NULL,
  UUIDTIMBREPAGO Varchar(36) NOT NULL,
  FECHAPAGO Timestamp,
  FORMAPAGOP Varchar(3),
  MONEDAP Varchar(3),
  TIPOCAMBIOP Double precision,
  IMPORTE Double precision,
  NUMOPERACION Varchar(50),
  RFCEMISORCTAORD Varchar(40),
  NOMBREBANCOORDEXT Varchar(300),
  CTAORDENANTE Varchar(50),
  RFCEMISORCTABEN Varchar(40),
  CTABENEFICIARIO Varchar(50),
  TIPOCADPAGO Varchar(50),
  CERTPAGO Varchar(50),
  CADPAGO Varchar(100),
  SELLOPAGO Varchar(50),
  "VERSION" Varchar(50),
  CONSTRAINT PK_PAGO PRIMARY KEY (IDPAGO,UUIDTIMBREPAGO)
);
CREATE TABLE PARAMEMP
(
  IDEMP Integer NOT NULL,
  DIREC Varchar(30),
  POBL Varchar(30),
  COD_POS Varchar(5),
  RFC_EMP Varchar(30),
  CED_EMP Varchar(30),
  DIGCTA1 Integer,
  DIGCTA2 Integer,
  DIGCTA3 Integer,
  DIGCTA4 Integer,
  DIGCTA5 Integer,
  DIGCTA6 Integer,
  DIGCTA7 Integer,
  DIGCTA8 Integer,
  DIGCTA9 Integer,
  NIVELACTU Smallint,
  GUION_SINO Varchar(1),
  REDO_P Varchar(1),
  CAPSALINI Varchar(1),
  ASIGSECPOL Varchar(1),
  CONTABLINEA Varchar(1),
  MESCIERRE Smallint,
  SUBDIR Varchar(255),
  CAPCTASPOL Varchar(1),
  DEPTO_SINO Varchar(1),
  TRASPASO Varchar(1),
  CTMONEXT Varchar(1),
  CSTIPOCMB Varchar(1),
  CPTIPOCMB Varchar(1),
  CQUEMONEXT Varchar(1),
  CQUEMONCTB Varchar(1),
  CTAIVA Varchar(40),
  CTABANCO Varchar(50),
  CONMONTPOL Smallint,
  DRIVERCOI Smallint,
  ALIAS Varchar(255),
  FOLIOUNICO Integer,
  CAPTURADOS Varchar(1),
  POLDESCUAD Varchar(1),
  DIRTRAB Varchar(255),
  IVADEF Varchar(2),
  IVAENOPT Smallint,
  IVAENINGR Smallint,
  BUFFCUECUA Varchar(21),
  TIPOPERSONA Varchar(10),
  NACIONALIDAD Varchar(12),
  TIPOEMPRESA Varchar(25),
  FCONSTITUCION Varchar(10),
  REGIMEN Varchar(25),
  NOMBREREPRE Varchar(60),
  RFCREPRE Varchar(13),
  CURPREPRE Varchar(18),
  PODERNOT Varchar(30),
  TRASPASOSALDOS Smallint,
  NOMBRE Varchar(60),
  CCOSTOS Integer,
  CGRUPOS Integer,
  ETQCCOSTOS Varchar(40),
  ETQCGRUPOS Varchar(40),
  IVADEFIETU Varchar(2),
  TIPODECAPTURADIOT Smallint,
  TIPODECAPTURAIETU Smallint,
  CUENTAIVAACREDITABLE Varchar(31),
  CUENTAIVATRASLADADO Varchar(31),
  TIPOPOLIZA Varchar(2),
  TIPOPOLIZATER Varchar(2),
  GIRO Varchar(6),
  DEV_COMPRAS Varchar(21),
  DEV_VENTAS Varchar(21),
  GASTO_ACTIVO Varchar(21),
  IEPS_POR_ACREDITAR Varchar(21),
  IEPS_POR_TRASLADAR Varchar(21),
  IMP_LOCAL_RETENIDO Varchar(21),
  IMP_LOCAL_TRASLADADO Varchar(21),
  ISR_RETENIDO Varchar(21),
  IVA_ACREDITAR Varchar(21),
  IVA_POR_TRASLADAR Varchar(21),
  IVA_RETENIDO Varchar(21),
  VENTAS Varchar(21),
  RCERTIFICADO Varchar(1024),
  RLLAVEPRIVADA Varchar(1024),
  CONTRASENIALLAVEPRIVADA Varchar(256),
  PROVEEDORTIMBRADO Varchar(256),
  USUARIOTIMBRADO Varchar(256),
  CONTRASENIATIMBRADO Varchar(256),
  PROVEEDORCANCELACION Varchar(256),
  USUARIOCANCELACION Varchar(256),
  CONTRASENIACANCELACION Varchar(256),
  ESPACIOASPEL Varchar(256),
  USUARIOESPACIO Varchar(256),
  CONTRASENIAESPACIO Varchar(256),
  IDCATEGORIAESPACIO Integer DEFAULT 0,
  NOMBRECATEGORIAESPACIO Varchar(256),
  ASIGCATEGORIA Smallint,
  GDIOTAPARTIRCFDI Smallint,
  GUARDAROPEAUTO Smallint,
  CFDIENTODASLASPARTIDAS Smallint DEFAULT 0,
  LOGO Blob sub_type 0,
  FIELCERTIF Varchar(1024),
  FIELPRIVKEY Varchar(1024),
  CVEACCESOFIEL Varchar(1024),
  GENERAPOLIZACOSTOS Smallint DEFAULT 1,
  UUIDEMPRESA_INTERFAZ Varchar(36),
  CONTABILIZAAUTO_INTERFAZ Integer,
  CORREO_INTERFAZ Varchar(100),
  ACCES_INTERFAZ Varchar(15),
  CONSTRAINT PK_PARAMEMP PRIMARY KEY (IDEMP)
);
CREATE TABLE PARAMGEN
(
  TIPO_PARAM Varchar(20) NOT NULL,
  IDENPARAM Varchar(30) NOT NULL,
  DATEVALUE Timestamp,
  INTVALUE Integer,
  STRINGVALUE Varchar(300),
  STATPARAM Smallint DEFAULT 1,
  OBSERV Varchar(200),
  BLOBVALUE Blob sub_type 1,
  CONSTRAINT PK_PARAMGEN PRIMARY KEY (TIPO_PARAM,IDENPARAM)
);
CREATE TABLE PLANTILLAXRFC
(
  RFC Varchar(15) NOT NULL,
  CLASPLANTILLA Varchar(5) NOT NULL,
  NOMBREPLANTILLA Varchar(256),
  NOMBREPLANTILLA2 Varchar(256),
  USOCFDI Varchar(6) NOT NULL,
  "VERSION" Integer NOT NULL,
  CONSTRAINT PK_PLANTILLAXRFC PRIMARY KEY (RFC,CLASPLANTILLA,USOCFDI,"VERSION")
);
CREATE TABLE POLDINAMICA
(
  TITULO Varchar(256) NOT NULL,
  RUTAARCHIVO Varchar(512) NOT NULL,
  TIPO Varchar(5),
  CLAS_USR Varchar(256),
  "VERSION" Integer
);
CREATE TABLE POLIZAS24
(
  TIPO_POLI Varchar(2) NOT NULL,
  NUM_POLIZ Varchar(5) NOT NULL,
  PERIODO Smallint NOT NULL,
  EJERCICIO Integer NOT NULL,
  FECHA_POL Timestamp,
  CONCEP_PO Varchar(120),
  NUM_PART Integer,
  LOGAUDITA Varchar(1),
  CONTABILIZ Varchar(1),
  NUMPARCUA Smallint,
  TIENEDOCUMENTOS Smallint,
  PROCCONTAB Integer,
  ORIGEN Varchar(15),
  UUID Varchar(100),
  ESPOLIZAPRIVADA Integer DEFAULT 0,
  UUIDOP Varchar(40),
  DOC_SIGO Varchar(20),
  UUIDXML Varchar(36),
  UUIDSAE Varchar(36),
  CONSTRAINT PK_POLIZAS24 PRIMARY KEY (TIPO_POLI,NUM_POLIZ,PERIODO,EJERCICIO)
);
CREATE TABLE POLIZAS25
(
  TIPO_POLI Varchar(2) NOT NULL,
  NUM_POLIZ Varchar(5) NOT NULL,
  PERIODO Smallint NOT NULL,
  EJERCICIO Integer NOT NULL,
  FECHA_POL Timestamp,
  CONCEP_PO Varchar(120),
  NUM_PART Integer,
  LOGAUDITA Varchar(1),
  CONTABILIZ Varchar(1),
  NUMPARCUA Smallint,
  TIENEDOCUMENTOS Smallint,
  PROCCONTAB Integer,
  ORIGEN Varchar(15),
  UUID Varchar(100),
  ESPOLIZAPRIVADA Integer DEFAULT 0,
  UUIDOP Varchar(40),
  DOC_SIGO Varchar(20),
  UUIDXML Varchar(36),
  UUIDSAE Varchar(36),
  CONSTRAINT PK_POLIZAS25 PRIMARY KEY (TIPO_POLI,NUM_POLIZ,PERIODO,EJERCICIO)
);
CREATE TABLE PRESUP24
(
  EJERCICIO Integer NOT NULL,
  NUM_CTA Varchar(21) NOT NULL,
  PRESUP01 Double precision DEFAULT 0,
  PRESUP02 Double precision DEFAULT 0,
  PRESUP03 Double precision DEFAULT 0,
  PRESUP04 Double precision DEFAULT 0,
  PRESUP05 Double precision DEFAULT 0,
  PRESUP06 Double precision DEFAULT 0,
  PRESUP07 Double precision DEFAULT 0,
  PRESUP08 Double precision DEFAULT 0,
  PRESUP09 Double precision DEFAULT 0,
  PRESUP10 Double precision DEFAULT 0,
  PRESUP11 Double precision DEFAULT 0,
  PRESUP12 Double precision DEFAULT 0,
  PRESUP13 Double precision DEFAULT 0,
  PRESUP14 Double precision DEFAULT 0,
  CONSTRAINT PK_PRESUP24 PRIMARY KEY (EJERCICIO,NUM_CTA)
);
CREATE TABLE PRESUP25
(
  EJERCICIO Integer NOT NULL,
  NUM_CTA Varchar(21) NOT NULL,
  PRESUP01 Double precision DEFAULT 0,
  PRESUP02 Double precision DEFAULT 0,
  PRESUP03 Double precision DEFAULT 0,
  PRESUP04 Double precision DEFAULT 0,
  PRESUP05 Double precision DEFAULT 0,
  PRESUP06 Double precision DEFAULT 0,
  PRESUP07 Double precision DEFAULT 0,
  PRESUP08 Double precision DEFAULT 0,
  PRESUP09 Double precision DEFAULT 0,
  PRESUP10 Double precision DEFAULT 0,
  PRESUP11 Double precision DEFAULT 0,
  PRESUP12 Double precision DEFAULT 0,
  PRESUP13 Double precision DEFAULT 0,
  PRESUP14 Double precision DEFAULT 0,
  CONSTRAINT PK_PRESUP25 PRIMARY KEY (EJERCICIO,NUM_CTA)
);
CREATE TABLE PRESUPDP24
(
  EJERCICIO Integer NOT NULL,
  NUM_CTA Varchar(21) NOT NULL,
  DEPTO Smallint NOT NULL,
  PRESUP01 Double precision DEFAULT 0,
  PRESUP02 Double precision DEFAULT 0,
  PRESUP03 Double precision DEFAULT 0,
  PRESUP04 Double precision DEFAULT 0,
  PRESUP05 Double precision DEFAULT 0,
  PRESUP06 Double precision DEFAULT 0,
  PRESUP07 Double precision DEFAULT 0,
  PRESUP08 Double precision DEFAULT 0,
  PRESUP09 Double precision DEFAULT 0,
  PRESUP10 Double precision DEFAULT 0,
  PRESUP11 Double precision DEFAULT 0,
  PRESUP12 Double precision DEFAULT 0,
  PRESUP13 Double precision DEFAULT 0,
  PRESUP14 Double precision,
  CONSTRAINT PK_PRESUPDP24 PRIMARY KEY (EJERCICIO,NUM_CTA,DEPTO)
);
CREATE TABLE PRESUPDP25
(
  EJERCICIO Integer NOT NULL,
  NUM_CTA Varchar(21) NOT NULL,
  DEPTO Smallint NOT NULL,
  PRESUP01 Double precision DEFAULT 0,
  PRESUP02 Double precision DEFAULT 0,
  PRESUP03 Double precision DEFAULT 0,
  PRESUP04 Double precision DEFAULT 0,
  PRESUP05 Double precision DEFAULT 0,
  PRESUP06 Double precision DEFAULT 0,
  PRESUP07 Double precision DEFAULT 0,
  PRESUP08 Double precision DEFAULT 0,
  PRESUP09 Double precision DEFAULT 0,
  PRESUP10 Double precision DEFAULT 0,
  PRESUP11 Double precision DEFAULT 0,
  PRESUP12 Double precision DEFAULT 0,
  PRESUP13 Double precision DEFAULT 0,
  PRESUP14 Double precision,
  CONSTRAINT PK_PRESUPDP25 PRIMARY KEY (EJERCICIO,NUM_CTA,DEPTO)
);
CREATE TABLE RANGOS
(
  RANGO Integer NOT NULL,
  DESCRIP Varchar(100),
  CONSTRAINT PK_RANGOS PRIMARY KEY (RANGO)
);
CREATE TABLE REGPOL
(
  TRANSACCIO Integer NOT NULL,
  TIPOPOL Varchar(2),
  NUMPOL Varchar(5),
  FECHAPOL Timestamp,
  FECHAOPR Timestamp,
  SISTEMA Varchar(15),
  NUMUSR Integer,
  OPERACION Integer,
  STATUS Smallint,
  TIPPOLINTR Varchar(1),
  POLMODELO Varchar(255),
  REGCONCLI Integer,
  STATUSCLI Varchar(1),
  CONSTRAINT PK_REGPOL PRIMARY KEY (TRANSACCIO)
);
CREATE TABLE RFCTER
(
  RFCIDFISC Varchar(40) NOT NULL,
  TIPO Integer,
  NOMBRE Varchar(60),
  PAIS Varchar(3),
  NACIONAL Varchar(40),
  TIPOOP Integer,
  CLAVESAE Varchar(5),
  CUENTAGAS Varchar(21),
  ESMONTO Varchar(1),
  MONPORC Double precision,
  IVADEFAULT Double precision,
  PORCENTAJEIVA Double precision,
  PORCENTAJEISR Double precision,
  INCLUYEIVA Smallint,
  ESPROV Varchar(1),
  CTABANCARIA Varchar(50),
  BANCO Smallint,
  FRMPAGO Varchar(5),
  BANCOEXTRANJERO Varchar(225),
  ESIDFISCAL Integer DEFAULT 0,
  PLANTILLAPOLDIN Varchar(512) DEFAULT '0',
  ESRFCLISTANEGRA Smallint,
  CUENTACLIENTE Varchar(21),
  CUENTAPROVEEDORMASIVO Varchar(21),
  CUENTACLIENTEMASIVO Varchar(21),
  CUENTABANCOCOBRO Varchar(21),
  CUENTABANCOPAGO Varchar(21),
  ZONAFRONTERIZA Integer,
  JURISDICCION Varchar(300),
  ORIGEN Varchar(10),
  SITUACIONEFOS Varchar(25),
  CONSTRAINT PK_RFCTER PRIMARY KEY (RFCIDFISC)
);
CREATE TABLE SALDOS24
(
  NUM_CTA Varchar(21) NOT NULL,
  EJERCICIO Smallint NOT NULL,
  INICIAL Double precision DEFAULT 0,
  INICIALEX Double precision DEFAULT 0,
  CARGO01 Double precision DEFAULT 0,
  ABONO01 Double precision DEFAULT 0,
  CARGOEX01 Double precision DEFAULT 0,
  ABONOEX01 Double precision DEFAULT 0,
  CARGO02 Double precision DEFAULT 0,
  ABONO02 Double precision DEFAULT 0,
  CARGOEX02 Double precision DEFAULT 0,
  ABONOEX02 Double precision DEFAULT 0,
  CARGO03 Double precision DEFAULT 0,
  ABONO03 Double precision DEFAULT 0,
  CARGOEX03 Double precision DEFAULT 0,
  ABONOEX03 Double precision DEFAULT 0,
  CARGO04 Double precision DEFAULT 0,
  ABONO04 Double precision DEFAULT 0,
  CARGOEX04 Double precision DEFAULT 0,
  ABONOEX04 Double precision DEFAULT 0,
  CARGO05 Double precision DEFAULT 0,
  ABONO05 Double precision DEFAULT 0,
  CARGOEX05 Double precision DEFAULT 0,
  ABONOEX05 Double precision DEFAULT 0,
  CARGO06 Double precision DEFAULT 0,
  ABONO06 Double precision DEFAULT 0,
  CARGOEX06 Double precision DEFAULT 0,
  ABONOEX06 Double precision DEFAULT 0,
  CARGO07 Double precision DEFAULT 0,
  ABONO07 Double precision DEFAULT 0,
  CARGOEX07 Double precision DEFAULT 0,
  ABONOEX07 Double precision DEFAULT 0,
  CARGO08 Double precision DEFAULT 0,
  ABONO08 Double precision DEFAULT 0,
  CARGOEX08 Double precision DEFAULT 0,
  ABONOEX08 Double precision DEFAULT 0,
  CARGO09 Double precision DEFAULT 0,
  ABONO09 Double precision DEFAULT 0,
  CARGOEX09 Double precision DEFAULT 0,
  ABONOEX09 Double precision DEFAULT 0,
  CARGO10 Double precision DEFAULT 0,
  ABONO10 Double precision DEFAULT 0,
  CARGOEX10 Double precision DEFAULT 0,
  ABONOEX10 Double precision DEFAULT 0,
  CARGO11 Double precision DEFAULT 0,
  ABONO11 Double precision DEFAULT 0,
  CARGOEX11 Double precision DEFAULT 0,
  ABONOEX11 Double precision DEFAULT 0,
  CARGO12 Double precision DEFAULT 0,
  ABONO12 Double precision DEFAULT 0,
  CARGOEX12 Double precision DEFAULT 0,
  ABONOEX12 Double precision DEFAULT 0,
  CARGO13 Double precision DEFAULT 0,
  ABONO13 Double precision DEFAULT 0,
  CARGOEX13 Double precision DEFAULT 0,
  ABONOEX13 Double precision DEFAULT 0,
  CARGO14 Double precision DEFAULT 0,
  ABONO14 Double precision DEFAULT 0,
  CARGOEX14 Double precision DEFAULT 0,
  ABONOEX14 Double precision DEFAULT 0,
  MOV01 Smallint DEFAULT 0,
  MOV02 Smallint DEFAULT 0,
  MOV03 Smallint DEFAULT 0,
  MOV04 Smallint DEFAULT 0,
  MOV05 Smallint DEFAULT 0,
  MOV06 Smallint DEFAULT 0,
  MOV07 Smallint DEFAULT 0,
  MOV08 Smallint DEFAULT 0,
  MOV09 Smallint DEFAULT 0,
  MOV10 Smallint DEFAULT 0,
  MOV11 Smallint DEFAULT 0,
  MOV12 Smallint DEFAULT 0,
  MOV13 Smallint DEFAULT 0,
  MOV14 Smallint DEFAULT 0,
  CONSTRAINT PK_SALDOS24 PRIMARY KEY (NUM_CTA,EJERCICIO)
);
CREATE TABLE SALDOS25
(
  NUM_CTA Varchar(21) NOT NULL,
  EJERCICIO Smallint NOT NULL,
  INICIAL Double precision DEFAULT 0,
  INICIALEX Double precision DEFAULT 0,
  CARGO01 Double precision DEFAULT 0,
  ABONO01 Double precision DEFAULT 0,
  CARGOEX01 Double precision DEFAULT 0,
  ABONOEX01 Double precision DEFAULT 0,
  CARGO02 Double precision DEFAULT 0,
  ABONO02 Double precision DEFAULT 0,
  CARGOEX02 Double precision DEFAULT 0,
  ABONOEX02 Double precision DEFAULT 0,
  CARGO03 Double precision DEFAULT 0,
  ABONO03 Double precision DEFAULT 0,
  CARGOEX03 Double precision DEFAULT 0,
  ABONOEX03 Double precision DEFAULT 0,
  CARGO04 Double precision DEFAULT 0,
  ABONO04 Double precision DEFAULT 0,
  CARGOEX04 Double precision DEFAULT 0,
  ABONOEX04 Double precision DEFAULT 0,
  CARGO05 Double precision DEFAULT 0,
  ABONO05 Double precision DEFAULT 0,
  CARGOEX05 Double precision DEFAULT 0,
  ABONOEX05 Double precision DEFAULT 0,
  CARGO06 Double precision DEFAULT 0,
  ABONO06 Double precision DEFAULT 0,
  CARGOEX06 Double precision DEFAULT 0,
  ABONOEX06 Double precision DEFAULT 0,
  CARGO07 Double precision DEFAULT 0,
  ABONO07 Double precision DEFAULT 0,
  CARGOEX07 Double precision DEFAULT 0,
  ABONOEX07 Double precision DEFAULT 0,
  CARGO08 Double precision DEFAULT 0,
  ABONO08 Double precision DEFAULT 0,
  CARGOEX08 Double precision DEFAULT 0,
  ABONOEX08 Double precision DEFAULT 0,
  CARGO09 Double precision DEFAULT 0,
  ABONO09 Double precision DEFAULT 0,
  CARGOEX09 Double precision DEFAULT 0,
  ABONOEX09 Double precision DEFAULT 0,
  CARGO10 Double precision DEFAULT 0,
  ABONO10 Double precision DEFAULT 0,
  CARGOEX10 Double precision DEFAULT 0,
  ABONOEX10 Double precision DEFAULT 0,
  CARGO11 Double precision DEFAULT 0,
  ABONO11 Double precision DEFAULT 0,
  CARGOEX11 Double precision DEFAULT 0,
  ABONOEX11 Double precision DEFAULT 0,
  CARGO12 Double precision DEFAULT 0,
  ABONO12 Double precision DEFAULT 0,
  CARGOEX12 Double precision DEFAULT 0,
  ABONOEX12 Double precision DEFAULT 0,
  CARGO13 Double precision DEFAULT 0,
  ABONO13 Double precision DEFAULT 0,
  CARGOEX13 Double precision DEFAULT 0,
  ABONOEX13 Double precision DEFAULT 0,
  CARGO14 Double precision DEFAULT 0,
  ABONO14 Double precision DEFAULT 0,
  CARGOEX14 Double precision DEFAULT 0,
  ABONOEX14 Double precision DEFAULT 0,
  MOV01 Smallint DEFAULT 0,
  MOV02 Smallint DEFAULT 0,
  MOV03 Smallint DEFAULT 0,
  MOV04 Smallint DEFAULT 0,
  MOV05 Smallint DEFAULT 0,
  MOV06 Smallint DEFAULT 0,
  MOV07 Smallint DEFAULT 0,
  MOV08 Smallint DEFAULT 0,
  MOV09 Smallint DEFAULT 0,
  MOV10 Smallint DEFAULT 0,
  MOV11 Smallint DEFAULT 0,
  MOV12 Smallint DEFAULT 0,
  MOV13 Smallint DEFAULT 0,
  MOV14 Smallint DEFAULT 0,
  CONSTRAINT PK_SALDOS25 PRIMARY KEY (NUM_CTA,EJERCICIO)
);
CREATE TABLE SALDOSDP24
(
  NUM_CTA Varchar(21) NOT NULL,
  EJERCICIO Smallint NOT NULL,
  DEPTO Integer NOT NULL,
  INICIAL Double precision,
  INICIALEX Double precision DEFAULT 0,
  CARGO01 Double precision DEFAULT 0,
  ABONO01 Double precision DEFAULT 0,
  CARGOEX01 Double precision DEFAULT 0,
  ABONOEX01 Double precision DEFAULT 0,
  CARGO02 Double precision DEFAULT 0,
  ABONO02 Double precision DEFAULT 0,
  CARGOEX02 Double precision DEFAULT 0,
  ABONOEX02 Double precision DEFAULT 0,
  CARGO03 Double precision DEFAULT 0,
  ABONO03 Double precision DEFAULT 0,
  CARGOEX03 Double precision DEFAULT 0,
  ABONOEX03 Double precision DEFAULT 0,
  CARGO04 Double precision DEFAULT 0,
  ABONO04 Double precision DEFAULT 0,
  CARGOEX04 Double precision DEFAULT 0,
  ABONOEX04 Double precision DEFAULT 0,
  CARGO05 Double precision DEFAULT 0,
  ABONO05 Double precision DEFAULT 0,
  CARGOEX05 Double precision DEFAULT 0,
  ABONOEX05 Double precision DEFAULT 0,
  CARGO06 Double precision DEFAULT 0,
  ABONO06 Double precision DEFAULT 0,
  CARGOEX06 Double precision DEFAULT 0,
  ABONOEX06 Double precision DEFAULT 0,
  CARGO07 Double precision DEFAULT 0,
  ABONO07 Double precision DEFAULT 0,
  CARGOEX07 Double precision DEFAULT 0,
  ABONOEX07 Double precision DEFAULT 0,
  CARGO08 Double precision DEFAULT 0,
  ABONO08 Double precision DEFAULT 0,
  CARGOEX08 Double precision DEFAULT 0,
  ABONOEX08 Double precision DEFAULT 0,
  CARGO09 Double precision DEFAULT 0,
  ABONO09 Double precision DEFAULT 0,
  CARGOEX09 Double precision DEFAULT 0,
  ABONOEX09 Double precision DEFAULT 0,
  CARGO10 Double precision DEFAULT 0,
  ABONO10 Double precision DEFAULT 0,
  CARGOEX10 Double precision DEFAULT 0,
  ABONOEX10 Double precision DEFAULT 0,
  CARGO11 Double precision DEFAULT 0,
  ABONO11 Double precision DEFAULT 0,
  CARGOEX11 Double precision DEFAULT 0,
  ABONOEX11 Double precision DEFAULT 0,
  CARGO12 Double precision DEFAULT 0,
  ABONO12 Double precision DEFAULT 0,
  CARGOEX12 Double precision DEFAULT 0,
  ABONOEX12 Double precision DEFAULT 0,
  CARGO13 Double precision DEFAULT 0,
  ABONO13 Double precision DEFAULT 0,
  CARGOEX13 Double precision DEFAULT 0,
  ABONOEX13 Double precision DEFAULT 0,
  CARGO14 Double precision DEFAULT 0,
  ABONO14 Double precision DEFAULT 0,
  CARGOEX14 Double precision DEFAULT 0,
  ABONOEX14 Double precision DEFAULT 0,
  MOV01 Smallint DEFAULT 0,
  MOV02 Smallint DEFAULT 0,
  MOV03 Smallint DEFAULT 0,
  MOV04 Smallint DEFAULT 0,
  MOV05 Smallint DEFAULT 0,
  MOV06 Smallint DEFAULT 0,
  MOV07 Smallint DEFAULT 0,
  MOV08 Smallint DEFAULT 0,
  MOV09 Smallint DEFAULT 0,
  MOV10 Smallint DEFAULT 0,
  MOV11 Smallint DEFAULT 0,
  MOV12 Smallint DEFAULT 0,
  MOV13 Smallint DEFAULT 0,
  MOV14 Smallint DEFAULT 0,
  CONSTRAINT PK_SALDOSDP24 PRIMARY KEY (NUM_CTA,EJERCICIO,DEPTO)
);
CREATE TABLE SALDOSDP25
(
  NUM_CTA Varchar(21) NOT NULL,
  EJERCICIO Smallint NOT NULL,
  DEPTO Integer NOT NULL,
  INICIAL Double precision,
  INICIALEX Double precision DEFAULT 0,
  CARGO01 Double precision DEFAULT 0,
  ABONO01 Double precision DEFAULT 0,
  CARGOEX01 Double precision DEFAULT 0,
  ABONOEX01 Double precision DEFAULT 0,
  CARGO02 Double precision DEFAULT 0,
  ABONO02 Double precision DEFAULT 0,
  CARGOEX02 Double precision DEFAULT 0,
  ABONOEX02 Double precision DEFAULT 0,
  CARGO03 Double precision DEFAULT 0,
  ABONO03 Double precision DEFAULT 0,
  CARGOEX03 Double precision DEFAULT 0,
  ABONOEX03 Double precision DEFAULT 0,
  CARGO04 Double precision DEFAULT 0,
  ABONO04 Double precision DEFAULT 0,
  CARGOEX04 Double precision DEFAULT 0,
  ABONOEX04 Double precision DEFAULT 0,
  CARGO05 Double precision DEFAULT 0,
  ABONO05 Double precision DEFAULT 0,
  CARGOEX05 Double precision DEFAULT 0,
  ABONOEX05 Double precision DEFAULT 0,
  CARGO06 Double precision DEFAULT 0,
  ABONO06 Double precision DEFAULT 0,
  CARGOEX06 Double precision DEFAULT 0,
  ABONOEX06 Double precision DEFAULT 0,
  CARGO07 Double precision DEFAULT 0,
  ABONO07 Double precision DEFAULT 0,
  CARGOEX07 Double precision DEFAULT 0,
  ABONOEX07 Double precision DEFAULT 0,
  CARGO08 Double precision DEFAULT 0,
  ABONO08 Double precision DEFAULT 0,
  CARGOEX08 Double precision DEFAULT 0,
  ABONOEX08 Double precision DEFAULT 0,
  CARGO09 Double precision DEFAULT 0,
  ABONO09 Double precision DEFAULT 0,
  CARGOEX09 Double precision DEFAULT 0,
  ABONOEX09 Double precision DEFAULT 0,
  CARGO10 Double precision DEFAULT 0,
  ABONO10 Double precision DEFAULT 0,
  CARGOEX10 Double precision DEFAULT 0,
  ABONOEX10 Double precision DEFAULT 0,
  CARGO11 Double precision DEFAULT 0,
  ABONO11 Double precision DEFAULT 0,
  CARGOEX11 Double precision DEFAULT 0,
  ABONOEX11 Double precision DEFAULT 0,
  CARGO12 Double precision DEFAULT 0,
  ABONO12 Double precision DEFAULT 0,
  CARGOEX12 Double precision DEFAULT 0,
  ABONOEX12 Double precision DEFAULT 0,
  CARGO13 Double precision DEFAULT 0,
  ABONO13 Double precision DEFAULT 0,
  CARGOEX13 Double precision DEFAULT 0,
  ABONOEX13 Double precision DEFAULT 0,
  CARGO14 Double precision DEFAULT 0,
  ABONO14 Double precision DEFAULT 0,
  CARGOEX14 Double precision DEFAULT 0,
  ABONOEX14 Double precision DEFAULT 0,
  MOV01 Smallint DEFAULT 0,
  MOV02 Smallint DEFAULT 0,
  MOV03 Smallint DEFAULT 0,
  MOV04 Smallint DEFAULT 0,
  MOV05 Smallint DEFAULT 0,
  MOV06 Smallint DEFAULT 0,
  MOV07 Smallint DEFAULT 0,
  MOV08 Smallint DEFAULT 0,
  MOV09 Smallint DEFAULT 0,
  MOV10 Smallint DEFAULT 0,
  MOV11 Smallint DEFAULT 0,
  MOV12 Smallint DEFAULT 0,
  MOV13 Smallint DEFAULT 0,
  MOV14 Smallint DEFAULT 0,
  CONSTRAINT PK_SALDOSDP25 PRIMARY KEY (NUM_CTA,EJERCICIO,DEPTO)
);
CREATE TABLE TIPACTIV
(
  CLAVE Smallint NOT NULL,
  DESCRIP Varchar(20),
  DEDNORMAL Double precision,
  DEDIMED Double precision,
  MAXDED Double precision,
  METODODEP Varchar(1),
  DEPPROY Double precision,
  CTAAACTV Varchar(21),
  CTADEPRE Varchar(21),
  CTAGASTOS Varchar(21),
  CTAPERGAN Varchar(21),
  QUEMONEDA Smallint,
  CONSTRAINT PK_TIPACTIV PRIMARY KEY (CLAVE)
);
CREATE TABLE TIPOSPOL
(
  TIPO Varchar(2) NOT NULL,
  DESCRIP Varchar(15),
  CLASSAT Integer,
  CONSTRAINT PK_TIPOSPOL PRIMARY KEY (TIPO)
);
CREATE TABLE UUIDTIMBRES
(
  NUMREG Integer NOT NULL,
  UUIDTIMBRE Varchar(36) NOT NULL,
  MONTO Double precision,
  SERIE Varchar(100),
  FOLIO Varchar(100),
  RFCEMISOR Varchar(40),
  RFCRECEPTOR Varchar(30),
  ORDEN Integer,
  FECHA Timestamp,
  TIPOCOMPROBANTE Smallint,
  TIPOCAMBIO Double precision,
  VERSIONCFDI Varchar(6),
  MONEDA Varchar(3),
  CONSTRAINT PK_UUIDTIMBRES PRIMARY KEY (NUMREG,UUIDTIMBRE)
);
/********************* VIEWS **********************/

/******************* EXCEPTIONS *******************/

/******************** TRIGGERS ********************/


UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave'  where RDB$FIELD_NAME = 'CLAVE' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Localozacion'  where RDB$FIELD_NAME = 'LOCALIZ' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto original'  where RDB$FIELD_NAME = 'MONTORIG' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto original extranjero'  where RDB$FIELD_NAME = 'MONTORIGEX' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de adquisicion'  where RDB$FIELD_NAME = 'FECHAADQ' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Maximo deducible'  where RDB$FIELD_NAME = 'MAXDED' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor del mercado'  where RDB$FIELD_NAME = 'VALMER' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Depreciacion acumulada'  where RDB$FIELD_NAME = 'DEPACU' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Vida util'  where RDB$FIELD_NAME = 'VIDAUT' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo de depreciacion'  where RDB$FIELD_NAME = 'METDEP' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa de depreciacion'  where RDB$FIELD_NAME = 'TASDEP' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa de depreciacion fiscal'  where RDB$FIELD_NAME = 'TASDEPFIS' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estatus'  where RDB$FIELD_NAME = 'STATUS' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha eliminacion'  where RDB$FIELD_NAME = 'FECHAELIM' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de depto'  where RDB$FIELD_NAME = 'NUMDEPTO' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha ultima revaluacion'  where RDB$FIELD_NAME = 'FECHAULTRE' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de serie'  where RDB$FIELD_NAME = 'NUMSERIE' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Deduccion inmediata'  where RDB$FIELD_NAME = 'BANDEDINM' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha inicio depreciacion'  where RDB$FIELD_NAME = 'FECINIDEP' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha depreciacion fiscal'  where RDB$FIELD_NAME = 'FECINIDEPF' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Depreciacion acumulada fiscal'  where RDB$FIELD_NAME = 'DEPACUFISC' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Observaciones'  where RDB$FIELD_NAME = 'OBSERVACIO' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIO' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poliza de seguro'  where RDB$FIELD_NAME = 'POLIZASEG' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Compania asegurada'  where RDB$FIELD_NAME = 'COMPASEGU' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Agente de seguro'  where RDB$FIELD_NAME = 'AGENTESEG' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Telefono sieniestro'  where RDB$FIELD_NAME = 'TELSINIES' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Tipo cobertura'  where RDB$FIELD_NAME = 'TIPOCOBER' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto asegurado'  where RDB$FIELD_NAME = 'MONTOASEG' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Prima total'  where RDB$FIELD_NAME = 'PRIMATOTA' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Deducible'  where RDB$FIELD_NAME = 'DEDUCIBLE' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha vigencia'  where RDB$FIELD_NAME = 'FECVIGENC' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha proxima mantenimiento'  where RDB$FIELD_NAME = 'FECPROXMA' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha ultimo mantenimiento'  where RDB$FIELD_NAME = 'FECULTMAN' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo mantenimiento'  where RDB$FIELD_NAME = 'PERIODOMA' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Costo mantenimiento'  where RDB$FIELD_NAME = 'COSTOMANT' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Responsable del activo fijo'  where RDB$FIELD_NAME = 'RESPACTFIJO' and RDB$RELATION_NAME = 'ACTIVOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave'  where RDB$FIELD_NAME = 'CLAVE' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Localozacion'  where RDB$FIELD_NAME = 'LOCALIZ' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto original'  where RDB$FIELD_NAME = 'MONTORIG' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto original extranjero'  where RDB$FIELD_NAME = 'MONTORIGEX' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de adquisicion'  where RDB$FIELD_NAME = 'FECHAADQ' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Maximo deducible'  where RDB$FIELD_NAME = 'MAXDED' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor del mercado'  where RDB$FIELD_NAME = 'VALMER' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Depreciacion acumulada'  where RDB$FIELD_NAME = 'DEPACU' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Vida util'  where RDB$FIELD_NAME = 'VIDAUT' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo de depreciacion'  where RDB$FIELD_NAME = 'METDEP' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa de depreciacion'  where RDB$FIELD_NAME = 'TASDEP' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa de depreciacion fiscal'  where RDB$FIELD_NAME = 'TASDEPFIS' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estatus'  where RDB$FIELD_NAME = 'STATUS' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha eliminacion'  where RDB$FIELD_NAME = 'FECHAELIM' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de depto'  where RDB$FIELD_NAME = 'NUMDEPTO' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha ultima revaluacion'  where RDB$FIELD_NAME = 'FECHAULTRE' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de serie'  where RDB$FIELD_NAME = 'NUMSERIE' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Deduccion inmediata'  where RDB$FIELD_NAME = 'BANDEDINM' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha inicio depreciacion'  where RDB$FIELD_NAME = 'FECINIDEP' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha depreciacion fiscal'  where RDB$FIELD_NAME = 'FECINIDEPF' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Depreciacion acumulada fiscal'  where RDB$FIELD_NAME = 'DEPACUFISC' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Observaciones'  where RDB$FIELD_NAME = 'OBSERVACIO' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIO' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poliza de seguro'  where RDB$FIELD_NAME = 'POLIZASEG' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Compania asegurada'  where RDB$FIELD_NAME = 'COMPASEGU' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Agente de seguro'  where RDB$FIELD_NAME = 'AGENTESEG' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Telefono sieniestro'  where RDB$FIELD_NAME = 'TELSINIES' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Tipo cobertura'  where RDB$FIELD_NAME = 'TIPOCOBER' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto asegurado'  where RDB$FIELD_NAME = 'MONTOASEG' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Prima total'  where RDB$FIELD_NAME = 'PRIMATOTA' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Deducible'  where RDB$FIELD_NAME = 'DEDUCIBLE' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha vigencia'  where RDB$FIELD_NAME = 'FECVIGENC' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha proxima mantenimiento'  where RDB$FIELD_NAME = 'FECPROXMA' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha ultimo mantenimiento'  where RDB$FIELD_NAME = 'FECULTMAN' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo mantenimiento'  where RDB$FIELD_NAME = 'PERIODOMA' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Costo mantenimiento'  where RDB$FIELD_NAME = 'COSTOMANT' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Responsable del activo fijo'  where RDB$FIELD_NAME = 'RESPACTFIJO' and RDB$RELATION_NAME = 'ACTIVOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio cerrado'  where RDB$FIELD_NAME = 'CERRADO' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ordenado'  where RDB$FIELD_NAME = 'ORDENADO' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si requiere traspaso'  where RDB$FIELD_NAME = 'REQTRASP' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de polizas'  where RDB$FIELD_NAME = 'CTPOLIZAS' and RDB$RELATION_NAME = 'ADMPER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO_POLI' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero'  where RDB$FIELD_NAME = 'NUM_POLIZ' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la partida'  where RDB$FIELD_NAME = 'NUM_PART' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de registro'  where RDB$FIELD_NAME = 'FECHA_POL' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Concepto'  where RDB$FIELD_NAME = 'CONCEP_PO' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono o cargo'  where RDB$FIELD_NAME = 'DEBE_HABER' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto movimiento'  where RDB$FIELD_NAME = 'MONTOMOV' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero depto'  where RDB$FIELD_NAME = 'NUMDEPTO' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo cambio'  where RDB$FIELD_NAME = 'TIPCAMBIO' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrapartida'  where RDB$FIELD_NAME = 'CONTRAPAR' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'orden de la partida'  where RDB$FIELD_NAME = 'ORDEN' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Centro de costos'  where RDB$FIELD_NAME = 'CCOSTOS' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Grupos'  where RDB$FIELD_NAME = 'CGRUPOS' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'numero de registro de forma de pago'  where RDB$FIELD_NAME = 'IDINFADIPAR' and RDB$RELATION_NAME = 'AUXILIAR24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro de comprobantes'  where RDB$FIELD_NAME = 'IDUUID' and RDB$RELATION_NAME = 'AUXILIAR24';
CREATE DESCENDING INDEX IDX_SERIE124 ON AUXILIAR24 (NUM_CTA);
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO_POLI' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero'  where RDB$FIELD_NAME = 'NUM_POLIZ' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la partida'  where RDB$FIELD_NAME = 'NUM_PART' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de registro'  where RDB$FIELD_NAME = 'FECHA_POL' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Concepto'  where RDB$FIELD_NAME = 'CONCEP_PO' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono o cargo'  where RDB$FIELD_NAME = 'DEBE_HABER' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto movimiento'  where RDB$FIELD_NAME = 'MONTOMOV' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero depto'  where RDB$FIELD_NAME = 'NUMDEPTO' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo cambio'  where RDB$FIELD_NAME = 'TIPCAMBIO' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrapartida'  where RDB$FIELD_NAME = 'CONTRAPAR' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'orden de la partida'  where RDB$FIELD_NAME = 'ORDEN' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Centro de costos'  where RDB$FIELD_NAME = 'CCOSTOS' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Grupos'  where RDB$FIELD_NAME = 'CGRUPOS' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'numero de registro de forma de pago'  where RDB$FIELD_NAME = 'IDINFADIPAR' and RDB$RELATION_NAME = 'AUXILIAR25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro de comprobantes'  where RDB$FIELD_NAME = 'IDUUID' and RDB$RELATION_NAME = 'AUXILIAR25';
CREATE DESCENDING INDEX IDX_SERIE125 ON AUXILIAR25 (NUM_CTA);
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador'  where RDB$FIELD_NAME = 'ID' and RDB$RELATION_NAME = 'CCOSTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'CCOSTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador'  where RDB$FIELD_NAME = 'ID' and RDB$RELATION_NAME = 'CGRUPOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'CGRUPOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del complemento de pago'  where RDB$FIELD_NAME = 'UUIDTIMBREPAGO' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Serie del complemento'  where RDB$FIELD_NAME = 'SERIE' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio del complemento'  where RDB$FIELD_NAME = 'FOLIO' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha del complemento'  where RDB$FIELD_NAME = 'FECHA' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC emisor '  where RDB$FIELD_NAME = 'RFCEMISOR' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del emisor'  where RDB$FIELD_NAME = 'NOMBREEMISOR' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto total de los importes de los pagos '  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO_POLI' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero'  where RDB$FIELD_NAME = 'NUM_POLIZ' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta del complemento de pago'  where RDB$FIELD_NAME = 'RUTAXML' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'XML Complementos de pago'  where RDB$FIELD_NAME = 'XML' and RDB$RELATION_NAME = 'COMPLEMENTOSPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Conepto'  where RDB$FIELD_NAME = 'CONCEPTO' and RDB$RELATION_NAME = 'CONCEPTO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'CONCEPTO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para conceptos'  where RDB$FIELD_NAME = 'CTCONCEPTOS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para deptos'  where RDB$FIELD_NAME = 'CTDEPTOS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para monedas'  where RDB$FIELD_NAME = 'CTMONEDAS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para rangos'  where RDB$FIELD_NAME = 'CTRANGOS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para activos'  where RDB$FIELD_NAME = 'CTTIPACTIV' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para polizas'  where RDB$FIELD_NAME = 'CTREGPOL' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para la version del la DB'  where RDB$FIELD_NAME = 'VERBASDAT' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para centro de costos'  where RDB$FIELD_NAME = 'CCOSTOS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para grupos'  where RDB$FIELD_NAME = 'CGRUPOS' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para conceptos IETU'  where RDB$FIELD_NAME = 'CTCONCIETU' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para conceptos IVA trasladado'  where RDB$FIELD_NAME = 'CTCONCIVAT' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para conceptos IVA acreditable'  where RDB$FIELD_NAME = 'CTCONCIVAA' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para informacion de pago'  where RDB$FIELD_NAME = 'CTINFADIPAR' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para informacion de comprobantes'  where RDB$FIELD_NAME = 'CTUUIDCOMP' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para operaciones con terceros'  where RDB$FIELD_NAME = 'CTIDOTROSIMP' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para ingresos cobrados'  where RDB$FIELD_NAME = 'CTIDOTROSIMPING' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de la ultima descarga de la lista negra RFC SAT '  where RDB$FIELD_NAME = 'ULTIMADESC_LISTANEGRA' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para NIFs'  where RDB$FIELD_NAME = 'CTUNIF' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de control para esatdos financieros NIFs'  where RDB$FIELD_NAME = 'CTUEDOFINNIF' and RDB$RELATION_NAME = 'CONTROL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'CUENTA' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC fiscal'  where RDB$FIELD_NAME = 'RFCIDFISC' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA default'  where RDB$FIELD_NAME = 'IVADEFAULT' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de IVA'  where RDB$FIELD_NAME = 'PORCENTAJEIVA' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de ISR'  where RDB$FIELD_NAME = 'PORCENTAJEISR' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si incluye o no IVA'  where RDB$FIELD_NAME = 'INCLUYEIVA' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador del concepto'  where RDB$FIELD_NAME = 'IDCONCEP' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'dentificador del concepto de iva trasladado'  where RDB$FIELD_NAME = 'IDCONCEPIVAT' and RDB$RELATION_NAME = 'CTAING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID del rubro NIF'  where RDB$FIELD_NAME = 'ID_NIF' and RDB$RELATION_NAME = 'CTANIF';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable asociada'  where RDB$FIELD_NAME = 'CUENTA' and RDB$RELATION_NAME = 'CTANIF';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Rubro'  where RDB$FIELD_NAME = 'RUBRO' and RDB$RELATION_NAME = 'CTARUB';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta'  where RDB$FIELD_NAME = 'CUENTA' and RDB$RELATION_NAME = 'CTARUB';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta papa'  where RDB$FIELD_NAME = 'SEGPAPA' and RDB$RELATION_NAME = 'CTARUB';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave del producto o servicio SAT, solo caracteres numericos'  where RDB$FIELD_NAME = 'CVE_PRODSERV' and RDB$RELATION_NAME = 'CTAS_PRODSERV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable para comprobantes de ventas'  where RDB$FIELD_NAME = 'NUM_CTA_VENTA' and RDB$RELATION_NAME = 'CTAS_PRODSERV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable para comprobantes de compras '  where RDB$FIELD_NAME = 'NUM_CTA_COMPRA' and RDB$RELATION_NAME = 'CTAS_PRODSERV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'CUENTA' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC fiscal'  where RDB$FIELD_NAME = 'RFCIDFISC' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva default'  where RDB$FIELD_NAME = 'IVADEFAULT' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Porcentaje de IVA'  where RDB$FIELD_NAME = 'PORCENTAJEIVA' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de ISR'  where RDB$FIELD_NAME = 'PORCENTAJEISR' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si incluye iva'  where RDB$FIELD_NAME = 'INCLUYEIVA' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave del concepto'  where RDB$FIELD_NAME = 'IDCONCEP' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Clave del concepto con iva'  where RDB$FIELD_NAME = 'IDCONCEPIVAA' and RDB$RELATION_NAME = 'CTATER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estado'  where RDB$FIELD_NAME = 'STATUS' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Es departamental o no'  where RDB$FIELD_NAME = 'DEPTSINO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Maneja multimoneda'  where RDB$FIELD_NAME = 'BANDMULTI' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si afecta poliza  de ajuste cambiario'  where RDB$FIELD_NAME = 'BANDAJT' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta papa'  where RDB$FIELD_NAME = 'CTA_PAPA' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta raiz'  where RDB$FIELD_NAME = 'CTA_RAIZ' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nivel'  where RDB$FIELD_NAME = 'NIVEL' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contrapartida'  where RDB$FIELD_NAME = 'CTA_COMP' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Naturaleza'  where RDB$FIELD_NAME = 'NATURALEZA' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC'  where RDB$FIELD_NAME = 'RFC' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Codigo de agrupacion'  where RDB$FIELD_NAME = 'CODAGRUP' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura formas de pago'  where RDB$FIELD_NAME = 'CAPTURACHEQUE' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura comprobantes'  where RDB$FIELD_NAME = 'CAPTURAUUID' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco capturado en la forma de pago'  where RDB$FIELD_NAME = 'BANCO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta bancaria capturada en la forma de pago'  where RDB$FIELD_NAME = 'CTABANCARIA' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de movimiento'  where RDB$FIELD_NAME = 'CAPCHEQTIPOMOV' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que no se incluira al general el xml de contabilidad'  where RDB$FIELD_NAME = 'NOINCLUIRXML' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador Fiscal'  where RDB$FIELD_NAME = 'IDFISCAL' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es flujo de efectivo'  where RDB$FIELD_NAME = 'ESFLUJODEEFECTIVO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco extranjero'  where RDB$FIELD_NAME = 'BANCOEXTRANJERO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFCEmisor Cuenta ordenante o RFCEmisor cuenta beneficiario'  where RDB$FIELD_NAME = 'RFCFLUJO' and RDB$RELATION_NAME = 'CUENTAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estado'  where RDB$FIELD_NAME = 'STATUS' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Es departamental o no'  where RDB$FIELD_NAME = 'DEPTSINO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Maneja multimoneda'  where RDB$FIELD_NAME = 'BANDMULTI' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si afecta poliza  de ajuste cambiario'  where RDB$FIELD_NAME = 'BANDAJT' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta papa'  where RDB$FIELD_NAME = 'CTA_PAPA' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta raiz'  where RDB$FIELD_NAME = 'CTA_RAIZ' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nivel'  where RDB$FIELD_NAME = 'NIVEL' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contrapartida'  where RDB$FIELD_NAME = 'CTA_COMP' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Naturaleza'  where RDB$FIELD_NAME = 'NATURALEZA' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC'  where RDB$FIELD_NAME = 'RFC' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Codigo de agrupacion'  where RDB$FIELD_NAME = 'CODAGRUP' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura formas de pago'  where RDB$FIELD_NAME = 'CAPTURACHEQUE' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura comprobantes'  where RDB$FIELD_NAME = 'CAPTURAUUID' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco capturado en la forma de pago'  where RDB$FIELD_NAME = 'BANCO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta bancaria capturada en la forma de pago'  where RDB$FIELD_NAME = 'CTABANCARIA' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de movimiento'  where RDB$FIELD_NAME = 'CAPCHEQTIPOMOV' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que no se incluira al general el xml de contabilidad'  where RDB$FIELD_NAME = 'NOINCLUIRXML' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador Fiscal'  where RDB$FIELD_NAME = 'IDFISCAL' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es flujo de efectivo'  where RDB$FIELD_NAME = 'ESFLUJODEEFECTIVO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco extranjero'  where RDB$FIELD_NAME = 'BANCOEXTRANJERO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFCEmisor Cuenta ordenante o RFCEmisor cuenta beneficiario'  where RDB$FIELD_NAME = 'RFCFLUJO' and RDB$RELATION_NAME = 'CUENTAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Depto'  where RDB$FIELD_NAME = 'DEPTO' and RDB$RELATION_NAME = 'DEPTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descirpcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'DEPTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPOPOL' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero'  where RDB$FIELD_NAME = 'NUMPOL' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de registro'  where RDB$FIELD_NAME = 'FECHAPOL' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida'  where RDB$FIELD_NAME = 'NUMPART' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indice'  where RDB$FIELD_NAME = 'INDICE' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'CUENTAGAS' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto de deduccion'  where RDB$FIELD_NAME = 'MONTODED' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de deduccion'  where RDB$FIELD_NAME = 'PORCDED' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador del concepto'  where RDB$FIELD_NAME = 'IDCONCEP' and RDB$RELATION_NAME = 'DESIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha en que se ingresa el registro del documento SAE'  where RDB$FIELD_NAME = 'FECHA_SINC' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Sistema de donde proviene el documento'  where RDB$FIELD_NAME = 'ORIGEN' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave para los tipos de documentos SAE. ventas = F, cuentas por cobrar = PC, devoluciones sobre venta = D, nota de credito = E, compras = c, cuentas por pagar = PP,devoluciones sobre compra = d'  where RDB$FIELD_NAME = 'TIPO_DOC' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha del documento, dada por SAE'  where RDB$FIELD_NAME = 'FECHA_DOCTO' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estado del documento, dado por SAE. Cancelado = C, Emitido = A'  where RDB$FIELD_NAME = 'ESTATUS' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Referencia del documento (Serie + Folio), dada por SAE'  where RDB$FIELD_NAME = 'REFERENCIA' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'XML de la operacion de SAE'  where RDB$FIELD_NAME = 'XML' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si el documento esta contabilizado. Contabilizado = S, No Contabilizado = N'  where RDB$FIELD_NAME = 'CONTABILIZ' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha en la que COI contabiliza el documento'  where RDB$FIELD_NAME = 'FECHA_CONTA' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo y Folio de la poliza generada en COI'  where RDB$FIELD_NAME = 'POLIZA' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo de la poliza generada en COI'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio de la poliza generada en COI'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Detalle que muestra el motivo por el cual no se contabiliza el documento'  where RDB$FIELD_NAME = 'OBS' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IDOperacion Identifica al registro para sincronizacion'  where RDB$FIELD_NAME = 'UUID_SINC' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador del XML de la operacion'  where RDB$FIELD_NAME = 'UUID_XML' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del tercero de la operacion'  where RDB$FIELD_NAME = 'RAZONSOCIAL' and RDB$RELATION_NAME = 'DIARIOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave para los documentos SAE. ventas = F, cuentas por cobrar = PC, devoluciones sobre venta = D, nota de credito = E, compras = c, cuentas por pagar = PP,devoluciones sobre compra = d'  where RDB$FIELD_NAME = 'TIPO_DOC' and RDB$RELATION_NAME = 'DOCTOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Documento de SAE'  where RDB$FIELD_NAME = 'DOCTO' and RDB$RELATION_NAME = 'DOCTOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Plantilla de COI asociada'  where RDB$FIELD_NAME = 'PLANTILLA' and RDB$RELATION_NAME = 'DOCTOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del nodo TimbreFiscalDigital del CFDI'  where RDB$FIELD_NAME = 'UUIDTIMBRECFDI' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta del archivo'  where RDB$FIELD_NAME = 'RUTAARCHIVO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total'  where RDB$FIELD_NAME = 'TOTAL' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Subtotal'  where RDB$FIELD_NAME = 'SUBTOTAL' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC del emisor'  where RDB$FIELD_NAME = 'RFCEMISOR' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC del receptor'  where RDB$FIELD_NAME = 'RFCRECEPTOR' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de emision del documento'  where RDB$FIELD_NAME = 'FECHAEMISION' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Serie del documento'  where RDB$FIELD_NAME = 'SERIE' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio del documento'  where RDB$FIELD_NAME = 'FOLIO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Version del documento'  where RDB$FIELD_NAME = 'VERSIONCFDI' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Lugar de expedicion'  where RDB$FIELD_NAME = 'LUGAREXPEDICION' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda'  where RDB$FIELD_NAME = 'MONEDA' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta del pago'  where RDB$FIELD_NAME = 'NUMCTAPAGO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descuento'  where RDB$FIELD_NAME = 'DESCUENTO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Forma de pago'  where RDB$FIELD_NAME = 'FORMAPAGO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo de pago'  where RDB$FIELD_NAME = 'METODOPAGO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de traslados'  where RDB$FIELD_NAME = 'TOTALIMPUESTOSTRASLADADOS' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de retenidos'  where RDB$FIELD_NAME = 'TOTALIMPUESTOSRETENIDOS' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del emisor'  where RDB$FIELD_NAME = 'NOMBREEMISOR' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del receptor'  where RDB$FIELD_NAME = 'NOMBRERECEPTOR' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Regimen fiscal '  where RDB$FIELD_NAME = 'REGIMENFISCAL' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UsoCDFI del nodo cfdi:Receptor  '  where RDB$FIELD_NAME = 'USOCFDI' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Sello timbrado  '  where RDB$FIELD_NAME = 'SELLOCFDI' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'NoCertificado del nodo cfdi:Comprobante'  where RDB$FIELD_NAME = 'NOCERTIFICADO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'NoCertificadoSATdel nodo tfd:TimbreFiscalDigital '  where RDB$FIELD_NAME = 'NOCERTIFICADOTIMBRE' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Condiciones de pago '  where RDB$FIELD_NAME = 'CONDICIONESDEPAGO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'sello del documento  '  where RDB$FIELD_NAME = 'SELLO' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo del comprobante '  where RDB$FIELD_NAME = 'TIPODECOMPROBANTE' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'XML CFDI'  where RDB$FIELD_NAME = 'XML' and RDB$RELATION_NAME = 'DOCTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del  CFDI'  where RDB$FIELD_NAME = 'UUIDTIMBRECFDI' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de complemento de pago'  where RDB$FIELD_NAME = 'UUIDTIMBREPAGO' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'id incremental del  pago'  where RDB$FIELD_NAME = 'IDPAGO' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Serie del CFDI'  where RDB$FIELD_NAME = 'SERIE' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio del CFDI'  where RDB$FIELD_NAME = 'FOLIO' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda  '  where RDB$FIELD_NAME = 'MONEDADR' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio '  where RDB$FIELD_NAME = 'TIPOCAMBIODR' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo de pago'  where RDB$FIELD_NAME = 'METODODEPAGODR' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del banco extranjero '  where RDB$FIELD_NAME = 'NUMPARCIALIDAD' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Importe del saldo anterior '  where RDB$FIELD_NAME = 'IMPSALDOANT' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'importe pagado '  where RDB$FIELD_NAME = 'IMPPAGADO' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'importe insoluto(tdCFDI:t_importe)'  where RDB$FIELD_NAME = 'IMPSALDOINSOLUTO' and RDB$RELATION_NAME = 'DOCTOSRELPAGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID del estado financiero, 1= B6 Estado de situacion financiera, 2= B3 Estado de Resultados Integral'  where RDB$FIELD_NAME = 'ID_EDO' and RDB$RELATION_NAME = 'EDOFINNIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del estado financiero'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'EDOFINNIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID del rubro NIF (solo de nivel 1) relacionado'  where RDB$FIELD_NAME = 'ID_NIF' and RDB$RELATION_NAME = 'EDOFINNIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'etiqueta que viene en el archivo de importación'  where RDB$FIELD_NAME = 'ETIQUETA' and RDB$RELATION_NAME = 'ETIQ_CCOSTOS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor de la columna Descripción de la matriz de homologación'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'ETIQ_CCOSTOS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Centro de Costos del sistema COI asignada'  where RDB$FIELD_NAME = 'CCOSTOS_COI' and RDB$RELATION_NAME = 'ETIQ_CCOSTOS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'etiqueta que viene en la poliza dinamica'  where RDB$FIELD_NAME = 'ETIQUETA' and RDB$RELATION_NAME = 'ETIQ_CTAS_POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'definicion de la etiqueta'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'ETIQ_CTAS_POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'cuenta contable del sistema COI que sustituye la etiqueta'  where RDB$FIELD_NAME = 'CUENTA_COI' and RDB$RELATION_NAME = 'ETIQ_CTAS_POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Origen o tipo de la etiqueta donde 0 seria el valor de las etiquetas que vienen por default y 1 el valor de las etiquetas que agrega el usuario'  where RDB$FIELD_NAME = 'ORIGEN' and RDB$RELATION_NAME = 'ETIQ_CTAS_POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'etiqueta o RFC que viene en el archivo de importación'  where RDB$FIELD_NAME = 'ETIQUETA' and RDB$RELATION_NAME = 'ETIQ_CTAS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor de la columna Operación de la matriz de homologación'  where RDB$FIELD_NAME = 'OPERACION' and RDB$RELATION_NAME = 'ETIQ_CTAS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor de la columna Descripción de la matriz de homologación'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'ETIQ_CTAS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'cuenta contable del sistema COI asignada'  where RDB$FIELD_NAME = 'CUENTA_COI' and RDB$RELATION_NAME = 'ETIQ_CTAS_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'etiqueta que viene en el archivo de importación'  where RDB$FIELD_NAME = 'ETIQUETA' and RDB$RELATION_NAME = 'ETIQ_OPERACION_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor de la columna Operación de la matriz de homologación'  where RDB$FIELD_NAME = 'OPERACION' and RDB$RELATION_NAME = 'ETIQ_OPERACION_SIGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza'  where RDB$FIELD_NAME = 'TIPPOL' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 1'  where RDB$FIELD_NAME = 'FOLIO01' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 2'  where RDB$FIELD_NAME = 'FOLIO02' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 3'  where RDB$FIELD_NAME = 'FOLIO03' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 4'  where RDB$FIELD_NAME = 'FOLIO04' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 5'  where RDB$FIELD_NAME = 'FOLIO05' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 6'  where RDB$FIELD_NAME = 'FOLIO06' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 7'  where RDB$FIELD_NAME = 'FOLIO07' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 8'  where RDB$FIELD_NAME = 'FOLIO08' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 9'  where RDB$FIELD_NAME = 'FOLIO09' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 10'  where RDB$FIELD_NAME = 'FOLIO10' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 11'  where RDB$FIELD_NAME = 'FOLIO11' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 12'  where RDB$FIELD_NAME = 'FOLIO12' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 13'  where RDB$FIELD_NAME = 'FOLIO13' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 1'  where RDB$FIELD_NAME = 'ASIG01' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 2'  where RDB$FIELD_NAME = 'ASIG02' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 3'  where RDB$FIELD_NAME = 'ASIG03' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 4'  where RDB$FIELD_NAME = 'ASIG04' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 5'  where RDB$FIELD_NAME = 'ASIG05' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 6'  where RDB$FIELD_NAME = 'ASIG06' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 7'  where RDB$FIELD_NAME = 'ASIG07' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 8'  where RDB$FIELD_NAME = 'ASIG08' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 9'  where RDB$FIELD_NAME = 'ASIG09' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 10'  where RDB$FIELD_NAME = 'ASIG10' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 11'  where RDB$FIELD_NAME = 'ASIG11' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 12'  where RDB$FIELD_NAME = 'ASIG12' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 13'  where RDB$FIELD_NAME = 'ASIG13' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica que ya se ha asignado folio al mes 14'  where RDB$FIELD_NAME = 'ASIG14' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de folio para el mes 14'  where RDB$FIELD_NAME = 'FOLIO14' and RDB$RELATION_NAME = 'FOLIOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda'  where RDB$FIELD_NAME = 'MONEDA' and RDB$RELATION_NAME = 'HISTOR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha registro'  where RDB$FIELD_NAME = 'FECHA' and RDB$RELATION_NAME = 'HISTOR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPCAMBIO' and RDB$RELATION_NAME = 'HISTOR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Titulo'  where RDB$FIELD_NAME = 'TITULO' and RDB$RELATION_NAME = 'HOJAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Hoja'  where RDB$FIELD_NAME = 'HOJAXLS' and RDB$RELATION_NAME = 'HOJAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo hoja'  where RDB$FIELD_NAME = 'TIPOHOJA' and RDB$RELATION_NAME = 'HOJAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave  '  where RDB$FIELD_NAME = 'NUMIMPUESTO' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID timbre del cfdi'  where RDB$FIELD_NAME = 'UUIDTIMBRECFDI' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del impuesto'  where RDB$FIELD_NAME = 'IMPUESTO' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'tipo del impuesto (0 Trasladado, 1 Retenido)'  where RDB$FIELD_NAME = 'TIPOIMPUESTO' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tiene impuesto local( 1 si y 0 no) '  where RDB$FIELD_NAME = 'ESLOCAL' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Base del impuesto'  where RDB$FIELD_NAME = 'BASE' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo factor (tasa ,cuota o exento)'  where RDB$FIELD_NAME = 'TIPOFACTOR' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor de la tasa o cuota '  where RDB$FIELD_NAME = 'TASACUOTA' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Importe '  where RDB$FIELD_NAME = 'IMPORTE' and RDB$RELATION_NAME = 'IMPUESTOSFISCALES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro'  where RDB$FIELD_NAME = 'NUMREG' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Forma de pago'  where RDB$FIELD_NAME = 'FRMPAGO' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cheque'  where RDB$FIELD_NAME = 'NUMCHEQUE' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clavel del banco'  where RDB$FIELD_NAME = 'BANCO' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta origen'  where RDB$FIELD_NAME = 'CTAORIG' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha'  where RDB$FIELD_NAME = 'FECHA' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Beneficiario'  where RDB$FIELD_NAME = 'BENEF' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC'  where RDB$FIELD_NAME = 'RFC' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco destino'  where RDB$FIELD_NAME = 'BANCODEST' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta destino'  where RDB$FIELD_NAME = 'CTADEST' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco origen extranjero'  where RDB$FIELD_NAME = 'BANCOORIGEXT' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco destino extranjero'  where RDB$FIELD_NAME = 'BANCODESTEXT' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador Fiscal'  where RDB$FIELD_NAME = 'IDFISCAL' and RDB$RELATION_NAME = 'INFADIPAR';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave que manda SAE para identificar al producto y servicio o linea de producto'  where RDB$FIELD_NAME = 'CLAVE' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion que mande SAE'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable para comprobantes de ventas'  where RDB$FIELD_NAME = 'NUM_CTA_VENTA' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta contable para comprobantes de compras '  where RDB$FIELD_NAME = 'NUM_CTA_COMPRA' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave para identificar al registro en cuestion: Lineas de producto = L, Productos y servicios = I, Almacen = A'  where RDB$FIELD_NAME = 'TIPO_REGISTRO' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha en que se ingresa el registro'  where RDB$FIELD_NAME = 'FECHA_SINC' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IDOperacion Identifica al registro para sincronizacion'  where RDB$FIELD_NAME = 'UUID_SINC' and RDB$RELATION_NAME = 'INFOSAE';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Enero'  where RDB$FIELD_NAME = 'MES1' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Febrero'  where RDB$FIELD_NAME = 'MES2' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Marzo'  where RDB$FIELD_NAME = 'MES3' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Abril'  where RDB$FIELD_NAME = 'MES4' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Mayo'  where RDB$FIELD_NAME = 'MES5' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Junio'  where RDB$FIELD_NAME = 'MES6' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Julio'  where RDB$FIELD_NAME = 'MES7' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Agosto'  where RDB$FIELD_NAME = 'MES8' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Septiembre'  where RDB$FIELD_NAME = 'MES9' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Octubre'  where RDB$FIELD_NAME = 'MES10' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Novimebre'  where RDB$FIELD_NAME = 'MES11' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'INCP de Diciembre'  where RDB$FIELD_NAME = 'MES12' and RDB$RELATION_NAME = 'INPC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC'  where RDB$FIELD_NAME = 'RFC' and RDB$RELATION_NAME = 'LISTANEGRARFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Situacion del contribuyente'  where RDB$FIELD_NAME = 'SITUACIONCONTRIBUYENTE' and RDB$RELATION_NAME = 'LISTANEGRARFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Publicacion pagina SAT '  where RDB$FIELD_NAME = 'PBPAGSAT' and RDB$RELATION_NAME = 'LISTANEGRARFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda'  where RDB$FIELD_NAME = 'MONEDA' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Prefijo'  where RDB$FIELD_NAME = 'PREFIJO' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha registro'  where RDB$FIELD_NAME = 'FECHA' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIO' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Desplazamiento automatico'  where RDB$FIELD_NAME = 'DESPAUTO' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave fiscal'  where RDB$FIELD_NAME = 'CLASSAT' and RDB$RELATION_NAME = 'MONEDAS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID del rubro NIF'  where RDB$FIELD_NAME = 'ID_NIF' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID del rubro padre'  where RDB$FIELD_NAME = 'ID_PADRE' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion del rubro NIF'  where RDB$FIELD_NAME = 'DESCRIPCION' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nivel del rubro NIF'  where RDB$FIELD_NAME = 'NIVEL' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nota financiera NIF'  where RDB$FIELD_NAME = 'NOTAFINNIF' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ID Raiz del rubro NIF'  where RDB$FIELD_NAME = 'ID_RAIZ' and RDB$RELATION_NAME = 'NIFS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPOPOL' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero'  where RDB$FIELD_NAME = 'NUMPOL' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha poliza'  where RDB$FIELD_NAME = 'FECHAPOL' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida'  where RDB$FIELD_NAME = 'NUMPART' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUMCTA' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC proveedor'  where RDB$FIELD_NAME = 'RFCPROVE' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo operacion'  where RDB$FIELD_NAME = 'TIPOPE' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto con IVA'  where RDB$FIELD_NAME = 'MONCONIVA' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto de ISR'  where RDB$FIELD_NAME = 'MONDEDISR' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de actos al 15 por ciento'  where RDB$FIELD_NAME = 'ACTOS15' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva pagado al 15 por ciento'  where RDB$FIELD_NAME = 'IVAOP15' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de actos al 10 por ciento'  where RDB$FIELD_NAME = 'ACTOS10' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva pagado al 10 por ciento'  where RDB$FIELD_NAME = 'IVAOP10' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos en cero'  where RDB$FIELD_NAME = 'ACTOSCERO' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos'  where RDB$FIELD_NAME = 'ACTOSEXENT' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva retenido'  where RDB$FIELD_NAME = 'IVARETENID' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva trasladado'  where RDB$FIELD_NAME = 'IVATRASLAD' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva devuelto'  where RDB$FIELD_NAME = 'IVADEVOLU' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cusacion'  where RDB$FIELD_NAME = 'PERCAUSAC' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva  no acreditable al 15 por ciento'  where RDB$FIELD_NAME = 'IVANOAC15' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva noa creditable al 10 por ciento'  where RDB$FIELD_NAME = 'IVANOAC10' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Es importacion'  where RDB$FIELD_NAME = 'ESIMPORTA' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de otras retenciones'  where RDB$FIELD_NAME = 'OTRASRET' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es devolucion'  where RDB$FIELD_NAME = 'ESDEVOL' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de ISR retenido'  where RDB$FIELD_NAME = 'ISRRETENID' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva general'  where RDB$FIELD_NAME = 'IVAGENERAL' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva fronterizo'  where RDB$FIELD_NAME = 'IVAFRONTERIZO' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador del concepto'  where RDB$FIELD_NAME = 'IDCONCEP' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ingreso excento'  where RDB$FIELD_NAME = 'INGREXENTO' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador del concepto de iva'  where RDB$FIELD_NAME = 'IDCONCEPIVAT' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador de operaciones IETU'  where RDB$FIELD_NAME = 'IDOPEIET' and RDB$RELATION_NAME = 'OPEIET';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza'  where RDB$FIELD_NAME = 'TIPOPOL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de poliza'  where RDB$FIELD_NAME = 'NUMPOL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha poliza'  where RDB$FIELD_NAME = 'FECHAPOL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la partida'  where RDB$FIELD_NAME = 'NUMPART' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la cuenta'  where RDB$FIELD_NAME = 'NUMCTA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC del proveedor'  where RDB$FIELD_NAME = 'RFCPROVE' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de operacion'  where RDB$FIELD_NAME = 'TIPOPE' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto con iva'  where RDB$FIELD_NAME = 'MONCONIVA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto de ISR'  where RDB$FIELD_NAME = 'MONDEDISR' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de actos al 15 por ciento'  where RDB$FIELD_NAME = 'ACTOS15' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva pagado al 15 por ciento'  where RDB$FIELD_NAME = 'IVAOP15' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Total de actos al 10 por ciento'  where RDB$FIELD_NAME = 'ACTOS10' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva pagado al 15 por ciento'  where RDB$FIELD_NAME = 'IVAOP10' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos en cero'  where RDB$FIELD_NAME = 'ACTOSCERO' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos'  where RDB$FIELD_NAME = 'ACTOSEXENT' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva retenido'  where RDB$FIELD_NAME = 'IVARETENID' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva trasladado'  where RDB$FIELD_NAME = 'IVATRASLAD' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva devuelto'  where RDB$FIELD_NAME = 'IVADEVOLU' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cusacion'  where RDB$FIELD_NAME = 'PERCAUSAC' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva no acreditable al 15 por ciento'  where RDB$FIELD_NAME = 'IVANOAC15' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva no acreditable al 10 por ciento'  where RDB$FIELD_NAME = 'IVANOAC10' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Es importacioin'  where RDB$FIELD_NAME = 'ESIMPORTA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'otras retenciones'  where RDB$FIELD_NAME = 'OTRASRET' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Es devolucion'  where RDB$FIELD_NAME = 'ESDEVOL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de ISR retenido'  where RDB$FIELD_NAME = 'ISRRETENID' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva genral'  where RDB$FIELD_NAME = 'IVAGENERAL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva fronterizo'  where RDB$FIELD_NAME = 'IVAFRONTERIZO' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Concepto iva'  where RDB$FIELD_NAME = 'IDCONCEPIVAA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se genero desde un CFDi'  where RDB$FIELD_NAME = 'DESDECFDI' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Id operación con terceros'  where RDB$FIELD_NAME = 'IDOPTER' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Importe IVA no acreditable a 8%'  where RDB$FIELD_NAME = 'IMPORTEIVANOREQ8' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Importe IVA no acreditable a 16% general'  where RDB$FIELD_NAME = 'IMPORTEIVANOREQ16_GENERAL' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del CFDI del cual se tomo la informacion'  where RDB$FIELD_NAME = 'UUID_XML' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valores posibles: 1=Tangible, 2=Intangible, 3=NA'  where RDB$FIELD_NAME = 'TIPOIMPORTACION' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valores posibles: 1=NA, 2=Norte, 3=Sur'  where RDB$FIELD_NAME = 'ZONAFRONTERIZA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA no acreditable Actividades exentas 8%'  where RDB$FIELD_NAME = 'IVANOAC_EXENTO8' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA no acreditable Actividades no objeto 8%'  where RDB$FIELD_NAME = 'IVANOAC_NOOBJETO8' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA no acreditable Actividades exentas 8%'  where RDB$FIELD_NAME = 'IVANOAC_EXENTO16' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA no acreditable Actividades no objeto 16%'  where RDB$FIELD_NAME = 'IVANOAC_NOOBJETO16' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'No objeto IVA territorio nacional'  where RDB$FIELD_NAME = 'NOOBJETO_IVANAC' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'No objeto IVA  sin establecimiento en territorio nacional'  where RDB$FIELD_NAME = 'NOOBJETO_IVASINNAC' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de proporcion de IVA'  where RDB$FIELD_NAME = 'PROPORCIONIVA' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Impuesto acreditable por proporcion 8%'  where RDB$FIELD_NAME = 'IVAAC_PROPORCION8' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Impuesto acreditable por proporcion 16%'  where RDB$FIELD_NAME = 'IVAAC_PROPORCION16' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos no acreditable al 8%'  where RDB$FIELD_NAME = 'ACTOSNOAC8' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Actos no acreditable al 16%'  where RDB$FIELD_NAME = 'ACTOSNOAC16' and RDB$RELATION_NAME = 'OPETER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Id operación con terceros'  where RDB$FIELD_NAME = 'IDOPTER' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro'  where RDB$FIELD_NAME = 'NUMREG' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del impuesto'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa o cuota del impuesto'  where RDB$FIELD_NAME = 'TASA' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es impuesto trasladado  ( 1= trasladado, 0 = retenido)'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Base del impuesto'  where RDB$FIELD_NAME = 'BASE' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica el tipo de impuesto (1=ISR, 2=IVA, 3=IEPS, 4= Impuesto local, 5= Otros impuestos, 6= Otras retenciones)'  where RDB$FIELD_NAME = 'TIPOIMPUESTO' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si el impuesto es involucrado en el calculo de DIOT, (1= si, 0 = no)'  where RDB$FIELD_NAME = 'APLICADIOT' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es  tasa o cuota (tasa , cuota)'  where RDB$FIELD_NAME = 'TIPOFACTOR' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de proporcion de IVA'  where RDB$FIELD_NAME = 'PROPORCIONIVA' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Impuesto acreditable por proporcion'  where RDB$FIELD_NAME = 'IVAAC_PROPORCION' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Impuesto no acreditable por proporcion'  where RDB$FIELD_NAME = 'IVANOAC_PROPORCION' and RDB$RELATION_NAME = 'OTROSIMPUESTOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Id de la tabla OPEIET '  where RDB$FIELD_NAME = 'IDOPEIET' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro'  where RDB$FIELD_NAME = 'NUMREG' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del impuesto'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tasa o cuota del impuesto'  where RDB$FIELD_NAME = 'TASA' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es impuesto trasladado  ( 1= trasladado, 0 = retenido)'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Base del impuesto'  where RDB$FIELD_NAME = 'BASE' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica el tipo de impuesto (1=ISR, 2=IVA, 3=IEPS, 4= Impuesto local, 5= Otros impuestos, 6= Otras retenciones)'  where RDB$FIELD_NAME = 'TIPOIMPUESTO' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si el impuesto es involucrado en el calculo de Ia tabla IETU, (1= si, 0 = no)'  where RDB$FIELD_NAME = 'APLICAIC' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es  tasa o cuota (tasa , cuota)'  where RDB$FIELD_NAME = 'TIPOFACTOR' and RDB$RELATION_NAME = 'OTROSIMPUESTOSING';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Id del pago incremental'  where RDB$FIELD_NAME = 'IDPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'id de complementos de pago'  where RDB$FIELD_NAME = 'UUIDTIMBREPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha del pago'  where RDB$FIELD_NAME = 'FECHAPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Forma de pago del complemento '  where RDB$FIELD_NAME = 'FORMAPAGOP' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda'  where RDB$FIELD_NAME = 'MONEDAP' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIOP' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'importe '  where RDB$FIELD_NAME = 'IMPORTE' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de operacion '  where RDB$FIELD_NAME = 'NUMOPERACION' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC emisor de la cuenta ordenante '  where RDB$FIELD_NAME = 'RFCEMISORCTAORD' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre del banco extranjero '  where RDB$FIELD_NAME = 'NOMBREBANCOORDEXT' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta ordenante '  where RDB$FIELD_NAME = 'CTAORDENANTE' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC emisor de la cuenta beneficiaria '  where RDB$FIELD_NAME = 'RFCEMISORCTABEN' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta beneficiaria '  where RDB$FIELD_NAME = 'CTABENEFICIARIO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Registra la clave del tipo de cadena de pago que genera la entidad receptora del pago. '  where RDB$FIELD_NAME = 'TIPOCADPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Certificado que corresponde al pago. '  where RDB$FIELD_NAME = 'CERTPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cadena original del comprobante de pago generado por la entidad emisora de la cuenta beneficiaria'  where RDB$FIELD_NAME = 'CADPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'sello digital que se asocie al pago.'  where RDB$FIELD_NAME = 'SELLOPAGO' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Version '  where RDB$FIELD_NAME = 'VERSION' and RDB$RELATION_NAME = 'PAGO';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identificador de la empresa'  where RDB$FIELD_NAME = 'IDEMP' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Direccion  de la empresa'  where RDB$FIELD_NAME = 'DIREC' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poblacion de la empresa'  where RDB$FIELD_NAME = 'POBL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Codigo postal'  where RDB$FIELD_NAME = 'COD_POS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC de la empresa'  where RDB$FIELD_NAME = 'RFC_EMP' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cedula de la empresa'  where RDB$FIELD_NAME = 'CED_EMP' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 1'  where RDB$FIELD_NAME = 'DIGCTA1' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 2'  where RDB$FIELD_NAME = 'DIGCTA2' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 3'  where RDB$FIELD_NAME = 'DIGCTA3' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 4'  where RDB$FIELD_NAME = 'DIGCTA4' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 5'  where RDB$FIELD_NAME = 'DIGCTA5' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 6'  where RDB$FIELD_NAME = 'DIGCTA6' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 7'  where RDB$FIELD_NAME = 'DIGCTA7' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 8'  where RDB$FIELD_NAME = 'DIGCTA8' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Digitos a capturar pora el nivel 9'  where RDB$FIELD_NAME = 'DIGCTA9' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Nivel actual de la cuenta'  where RDB$FIELD_NAME = 'NIVELACTU' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'La cuenta maneja guiones o no los maneja'  where RDB$FIELD_NAME = 'GUION_SINO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Se redondea'  where RDB$FIELD_NAME = 'REDO_P' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura saldo inicial'  where RDB$FIELD_NAME = 'CAPSALINI' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio secuencial'  where RDB$FIELD_NAME = 'ASIGSECPOL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se contbiliza en linea o no'  where RDB$FIELD_NAME = 'CONTABLINEA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Mes de cierre'  where RDB$FIELD_NAME = 'MESCIERRE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Subidiraccion'  where RDB$FIELD_NAME = 'SUBDIR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura una cuenta al crear una poliza'  where RDB$FIELD_NAME = 'CAPCTASPOL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si tiene depto o no'  where RDB$FIELD_NAME = 'DEPTO_SINO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Trapaso'  where RDB$FIELD_NAME = 'TRASPASO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si la cuenta es moneda extranjera'  where RDB$FIELD_NAME = 'CTMONEXT' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura tipo de cambio'  where RDB$FIELD_NAME = 'CSTIPOCMB' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura tipo de cambio'  where RDB$FIELD_NAME = 'CPTIPOCMB' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica  si  tiene moneda extranjera'  where RDB$FIELD_NAME = 'CQUEMONEXT' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se captura tipo de cambio'  where RDB$FIELD_NAME = 'CQUEMONCTB' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva de la cuenta'  where RDB$FIELD_NAME = 'CTAIVA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco de la cuenta'  where RDB$FIELD_NAME = 'CTABANCO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica monto poliza'  where RDB$FIELD_NAME = 'CONMONTPOL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Driver del sistema'  where RDB$FIELD_NAME = 'DRIVERCOI' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Alias del sistema'  where RDB$FIELD_NAME = 'ALIAS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio unico'  where RDB$FIELD_NAME = 'FOLIOUNICO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Si se encuentra capturado'  where RDB$FIELD_NAME = 'CAPTURADOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si la poliza esta descuadrada'  where RDB$FIELD_NAME = 'POLDESCUAD' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta de trabajo'  where RDB$FIELD_NAME = 'DIRTRAB' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA por omision'  where RDB$FIELD_NAME = 'IVADEF' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva para operaciones con terceros'  where RDB$FIELD_NAME = 'IVAENOPT' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva para ingresos'  where RDB$FIELD_NAME = 'IVAENINGR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de cuadre'  where RDB$FIELD_NAME = 'BUFFCUECUA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de persona'  where RDB$FIELD_NAME = 'TIPOPERSONA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nacionalidad'  where RDB$FIELD_NAME = 'NACIONALIDAD' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de empresa'  where RDB$FIELD_NAME = 'TIPOEMPRESA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha de constitucion'  where RDB$FIELD_NAME = 'FCONSTITUCION' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Regimen de la empresa'  where RDB$FIELD_NAME = 'REGIMEN' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre de la empresa'  where RDB$FIELD_NAME = 'NOMBREREPRE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC del representante  legal de la empresa'  where RDB$FIELD_NAME = 'RFCREPRE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Curp del representante legal de la empresa'  where RDB$FIELD_NAME = 'CURPREPRE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poder notarial'  where RDB$FIELD_NAME = 'PODERNOT' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si hay traspasos de  saldos'  where RDB$FIELD_NAME = 'TRASPASOSALDOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si habra centro de costos'  where RDB$FIELD_NAME = 'CCOSTOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si tendra grupos'  where RDB$FIELD_NAME = 'CGRUPOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Etiqueta para centro de costos'  where RDB$FIELD_NAME = 'ETQCCOSTOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Etiqueta para grupos'  where RDB$FIELD_NAME = 'ETQCGRUPOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA default para IETU'  where RDB$FIELD_NAME = 'IVADEFIETU' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de captura para diot'  where RDB$FIELD_NAME = 'TIPODECAPTURADIOT' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de captura para IETU'  where RDB$FIELD_NAME = 'TIPODECAPTURAIETU' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de IVA acreditable '  where RDB$FIELD_NAME = 'CUENTAIVAACREDITABLE' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta  de IIVA trasladado de la cuenta'  where RDB$FIELD_NAME = 'CUENTAIVATRASLADADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Tipo de la poliza'  where RDB$FIELD_NAME = 'TIPOPOLIZA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de poliza para terceros'  where RDB$FIELD_NAME = 'TIPOPOLIZATER' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Giro de la empresa'  where RDB$FIELD_NAME = 'GIRO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Devolucion de compras'  where RDB$FIELD_NAME = 'DEV_COMPRAS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Devolucion de ventas'  where RDB$FIELD_NAME = 'DEV_VENTAS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Gato activo'  where RDB$FIELD_NAME = 'GASTO_ACTIVO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Cuenta de IEPS por acreditar'  where RDB$FIELD_NAME = 'IEPS_POR_ACREDITAR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de IEPS por trasladar'  where RDB$FIELD_NAME = 'IEPS_POR_TRASLADAR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de impuesto local retenido'  where RDB$FIELD_NAME = 'IMP_LOCAL_RETENIDO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de impuesto local trasladado'  where RDB$FIELD_NAME = 'IMP_LOCAL_TRASLADADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'ISR retenido'  where RDB$FIELD_NAME = 'ISR_RETENIDO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA acreditar'  where RDB$FIELD_NAME = 'IVA_ACREDITAR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA por trasladar'  where RDB$FIELD_NAME = 'IVA_POR_TRASLADAR' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'IVA retenido'  where RDB$FIELD_NAME = 'IVA_RETENIDO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de ventas'  where RDB$FIELD_NAME = 'VENTAS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta del certificado'  where RDB$FIELD_NAME = 'RCERTIFICADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta de la llave privada'  where RDB$FIELD_NAME = 'RLLAVEPRIVADA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrasenia de la llave privada'  where RDB$FIELD_NAME = 'CONTRASENIALLAVEPRIVADA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Proveedor de timbrado'  where RDB$FIELD_NAME = 'PROVEEDORTIMBRADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Usuario de timbrado'  where RDB$FIELD_NAME = 'USUARIOTIMBRADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrasenia del timbrado'  where RDB$FIELD_NAME = 'CONTRASENIATIMBRADO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Proveedor de cancelacion'  where RDB$FIELD_NAME = 'PROVEEDORCANCELACION' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Usuario de cancelacion'  where RDB$FIELD_NAME = 'USUARIOCANCELACION' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'contrasenia de cancelacion'  where RDB$FIELD_NAME = 'CONTRASENIACANCELACION' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'eSPACIO Aspel'  where RDB$FIELD_NAME = 'ESPACIOASPEL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Usuario de eSPACIO Aspel'  where RDB$FIELD_NAME = 'USUARIOESPACIO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrasenia de eSPACIO Aspel'  where RDB$FIELD_NAME = 'CONTRASENIAESPACIO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Categoria de eSPACIO Aspel'  where RDB$FIELD_NAME = 'IDCATEGORIAESPACIO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre Categoria de eSPACIO Aspel'  where RDB$FIELD_NAME = 'NOMBRECATEGORIAESPACIO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'si permite indicar la categoría de un archivo'  where RDB$FIELD_NAME = 'ASIGCATEGORIA' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si la captura del diot sera a partir de CFDIs'  where RDB$FIELD_NAME = 'GDIOTAPARTIRCFDI' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si el guardado se realizara  de forma silencionsa'  where RDB$FIELD_NAME = 'GUARDAROPEAUTO' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si asocian los UUIDs a todas la partidas de póliza dinámica'  where RDB$FIELD_NAME = 'CFDIENTODASLASPARTIDAS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Certificado de la FIEL'  where RDB$FIELD_NAME = 'FIELCERTIF' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Llave del certificado de la FIEL'  where RDB$FIELD_NAME = 'FIELPRIVKEY' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave de acceso del certificado de la FIEL'  where RDB$FIELD_NAME = 'CVEACCESOFIEL' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si se genera en automatico la poliza de costos de venta para interfaz SAE-COI. 1 = Genera, 0 = NO Genera'  where RDB$FIELD_NAME = 'GENERAPOLIZACOSTOS' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de la empresa  para la nueva interfaz con SAE '  where RDB$FIELD_NAME = 'UUIDEMPRESA_INTERFAZ' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contabilizacion automatica al sincronizar  para la nueva interfaz con SAE  (0 =check apagado|1=check encendido)'  where RDB$FIELD_NAME = 'CONTABILIZAAUTO_INTERFAZ' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Correo de inicio de sesion de interfaz SAE'  where RDB$FIELD_NAME = 'CORREO_INTERFAZ' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Contrasenia de inicio de sesion de interfaz SAE'  where RDB$FIELD_NAME = 'ACCES_INTERFAZ' and RDB$RELATION_NAME = 'PARAMEMP';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo del parametro'  where RDB$FIELD_NAME = 'TIPO_PARAM' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave del parametro'  where RDB$FIELD_NAME = 'IDENPARAM' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor tipo fecha para el parametro'  where RDB$FIELD_NAME = 'DATEVALUE' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor tipo entero para el parametro'  where RDB$FIELD_NAME = 'INTVALUE' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor tipo string para el parametro'  where RDB$FIELD_NAME = 'STRINGVALUE' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estatus del parametro'  where RDB$FIELD_NAME = 'STATPARAM' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Observaciones del parametro'  where RDB$FIELD_NAME = 'OBSERV' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valor tipo blob para el parametro'  where RDB$FIELD_NAME = 'BLOBVALUE' and RDB$RELATION_NAME = 'PARAMGEN';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC del tercero'  where RDB$FIELD_NAME = 'RFC' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de cfdi para el que aplica la plantilla (1=factura,2=notacredito,3=credito,4=compPago) '  where RDB$FIELD_NAME = 'CLASPLANTILLA' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre de la plantilla para 1a contabilizacion del UUID'  where RDB$FIELD_NAME = 'NOMBREPLANTILLA' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre de la plantilla para 2a contabilizacion del UUID'  where RDB$FIELD_NAME = 'NOMBREPLANTILLA2' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Uso cfdi'  where RDB$FIELD_NAME = 'USOCFDI' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Campo para distinguir el tipo de plantilla que definió el usuario en la contabilidad masiva, donde 1 es para las plantillas que ya existen y 2 para las plantillas de contabilidad masiva'  where RDB$FIELD_NAME = 'VERSION' and RDB$RELATION_NAME = 'PLANTILLAXRFC';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Titulo del archivo'  where RDB$FIELD_NAME = 'TITULO' and RDB$RELATION_NAME = 'POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ruta del archivo '  where RDB$FIELD_NAME = 'RUTAARCHIVO' and RDB$RELATION_NAME = 'POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo '  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clasificacion segun el usuario'  where RDB$FIELD_NAME = 'CLAS_USR' and RDB$RELATION_NAME = 'POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Version de la plantilla siendo 1 el valor de las plantillas que ya se encuentren registradas, y 2 el valor de las plantillas que se agreguen para la generación masiva'  where RDB$FIELD_NAME = 'VERSION' and RDB$RELATION_NAME = 'POLDINAMICA';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza'  where RDB$FIELD_NAME = 'TIPO_POLI' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de poliza'  where RDB$FIELD_NAME = 'NUM_POLIZ' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha poliza'  where RDB$FIELD_NAME = 'FECHA_POL' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Concepto'  where RDB$FIELD_NAME = 'CONCEP_PO' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida'  where RDB$FIELD_NAME = 'NUM_PART' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poliza auditada'  where RDB$FIELD_NAME = 'LOGAUDITA' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Esta contabilizada'  where RDB$FIELD_NAME = 'CONTABILIZ' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida de la cuenta'  where RDB$FIELD_NAME = 'NUMPARCUA' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tiene documentos asosciados'  where RDB$FIELD_NAME = 'TIENEDOCUMENTOS' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de transaccion para la interfaz'  where RDB$FIELD_NAME = 'PROCCONTAB' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Origen'  where RDB$FIELD_NAME = 'ORIGEN' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del comprobante'  where RDB$FIELD_NAME = 'UUID' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Es poliza privada'  where RDB$FIELD_NAME = 'ESPOLIZAPRIVADA' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de la operacion asociada desde buzon contable-Espacio'  where RDB$FIELD_NAME = 'UUIDOP' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'documento referencia de Siigo que viene en el archivo de importación'  where RDB$FIELD_NAME = 'DOC_SIGO' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del XML con el que se genera la poliza'  where RDB$FIELD_NAME = 'UUIDXML' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de la operacion de SAE'  where RDB$FIELD_NAME = 'UUIDSAE' and RDB$RELATION_NAME = 'POLIZAS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza'  where RDB$FIELD_NAME = 'TIPO_POLI' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de poliza'  where RDB$FIELD_NAME = 'NUM_POLIZ' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Periodo'  where RDB$FIELD_NAME = 'PERIODO' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha poliza'  where RDB$FIELD_NAME = 'FECHA_POL' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Concepto'  where RDB$FIELD_NAME = 'CONCEP_PO' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida'  where RDB$FIELD_NAME = 'NUM_PART' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poliza auditada'  where RDB$FIELD_NAME = 'LOGAUDITA' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Esta contabilizada'  where RDB$FIELD_NAME = 'CONTABILIZ' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de partida de la cuenta'  where RDB$FIELD_NAME = 'NUMPARCUA' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tiene documentos asosciados'  where RDB$FIELD_NAME = 'TIENEDOCUMENTOS' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de transaccion para la interfaz'  where RDB$FIELD_NAME = 'PROCCONTAB' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Origen'  where RDB$FIELD_NAME = 'ORIGEN' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del comprobante'  where RDB$FIELD_NAME = 'UUID' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Es poliza privada'  where RDB$FIELD_NAME = 'ESPOLIZAPRIVADA' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de la operacion asociada desde buzon contable-Espacio'  where RDB$FIELD_NAME = 'UUIDOP' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'documento referencia de Siigo que viene en el archivo de importación'  where RDB$FIELD_NAME = 'DOC_SIGO' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del XML con el que se genera la poliza'  where RDB$FIELD_NAME = 'UUIDXML' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID de la operacion de SAE'  where RDB$FIELD_NAME = 'UUIDSAE' and RDB$RELATION_NAME = 'POLIZAS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 1'  where RDB$FIELD_NAME = 'PRESUP01' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 2'  where RDB$FIELD_NAME = 'PRESUP02' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 3'  where RDB$FIELD_NAME = 'PRESUP03' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 4'  where RDB$FIELD_NAME = 'PRESUP04' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 5'  where RDB$FIELD_NAME = 'PRESUP05' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 6'  where RDB$FIELD_NAME = 'PRESUP06' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 7'  where RDB$FIELD_NAME = 'PRESUP07' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 8'  where RDB$FIELD_NAME = 'PRESUP08' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 9'  where RDB$FIELD_NAME = 'PRESUP09' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 10'  where RDB$FIELD_NAME = 'PRESUP10' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 11'  where RDB$FIELD_NAME = 'PRESUP11' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 12'  where RDB$FIELD_NAME = 'PRESUP12' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 13'  where RDB$FIELD_NAME = 'PRESUP13' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 14'  where RDB$FIELD_NAME = 'PRESUP14' and RDB$RELATION_NAME = 'PRESUP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 1'  where RDB$FIELD_NAME = 'PRESUP01' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 2'  where RDB$FIELD_NAME = 'PRESUP02' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 3'  where RDB$FIELD_NAME = 'PRESUP03' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 4'  where RDB$FIELD_NAME = 'PRESUP04' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 5'  where RDB$FIELD_NAME = 'PRESUP05' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 6'  where RDB$FIELD_NAME = 'PRESUP06' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 7'  where RDB$FIELD_NAME = 'PRESUP07' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 8'  where RDB$FIELD_NAME = 'PRESUP08' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 9'  where RDB$FIELD_NAME = 'PRESUP09' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 10'  where RDB$FIELD_NAME = 'PRESUP10' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 11'  where RDB$FIELD_NAME = 'PRESUP11' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 12'  where RDB$FIELD_NAME = 'PRESUP12' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 13'  where RDB$FIELD_NAME = 'PRESUP13' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Presupuesto para el mes 14'  where RDB$FIELD_NAME = 'PRESUP14' and RDB$RELATION_NAME = 'PRESUP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Departamento'  where RDB$FIELD_NAME = 'DEPTO' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 1'  where RDB$FIELD_NAME = 'PRESUP01' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 2'  where RDB$FIELD_NAME = 'PRESUP02' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 3'  where RDB$FIELD_NAME = 'PRESUP03' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 4'  where RDB$FIELD_NAME = 'PRESUP04' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 5'  where RDB$FIELD_NAME = 'PRESUP05' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 6'  where RDB$FIELD_NAME = 'PRESUP06' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 7'  where RDB$FIELD_NAME = 'PRESUP07' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 8'  where RDB$FIELD_NAME = 'PRESUP08' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 9'  where RDB$FIELD_NAME = 'PRESUP09' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 10'  where RDB$FIELD_NAME = 'PRESUP10' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 11'  where RDB$FIELD_NAME = 'PRESUP11' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 12'  where RDB$FIELD_NAME = 'PRESUP12' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 13'  where RDB$FIELD_NAME = 'PRESUP13' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 14'  where RDB$FIELD_NAME = 'PRESUP14' and RDB$RELATION_NAME = 'PRESUPDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de la cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Departamento'  where RDB$FIELD_NAME = 'DEPTO' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 1'  where RDB$FIELD_NAME = 'PRESUP01' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 2'  where RDB$FIELD_NAME = 'PRESUP02' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 3'  where RDB$FIELD_NAME = 'PRESUP03' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 4'  where RDB$FIELD_NAME = 'PRESUP04' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 5'  where RDB$FIELD_NAME = 'PRESUP05' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 6'  where RDB$FIELD_NAME = 'PRESUP06' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 7'  where RDB$FIELD_NAME = 'PRESUP07' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 8'  where RDB$FIELD_NAME = 'PRESUP08' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 9'  where RDB$FIELD_NAME = 'PRESUP09' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 10'  where RDB$FIELD_NAME = 'PRESUP10' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 11'  where RDB$FIELD_NAME = 'PRESUP11' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 12'  where RDB$FIELD_NAME = 'PRESUP12' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 13'  where RDB$FIELD_NAME = 'PRESUP13' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Presupuesto para el mes 14'  where RDB$FIELD_NAME = 'PRESUP14' and RDB$RELATION_NAME = 'PRESUPDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Rango'  where RDB$FIELD_NAME = 'RANGO' and RDB$RELATION_NAME = 'RANGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'RANGOS';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de transaccion'  where RDB$FIELD_NAME = 'TRANSACCIO' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza'  where RDB$FIELD_NAME = 'TIPOPOL' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de poliza'  where RDB$FIELD_NAME = 'NUMPOL' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha poliza'  where RDB$FIELD_NAME = 'FECHAPOL' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha operacion'  where RDB$FIELD_NAME = 'FECHAOPR' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Sistema'  where RDB$FIELD_NAME = 'SISTEMA' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de usuario de interfaz'  where RDB$FIELD_NAME = 'NUMUSR' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Operacion'  where RDB$FIELD_NAME = 'OPERACION' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estatus'  where RDB$FIELD_NAME = 'STATUS' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo poliza interfaz'  where RDB$FIELD_NAME = 'TIPPOLINTR' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Poliza modelo'  where RDB$FIELD_NAME = 'POLMODELO' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Registro de cliente'  where RDB$FIELD_NAME = 'REGCONCLI' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estatus de clientes'  where RDB$FIELD_NAME = 'STATUSCLI' and RDB$RELATION_NAME = 'REGPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC fiscal'  where RDB$FIELD_NAME = 'RFCIDFISC' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nombre'  where RDB$FIELD_NAME = 'NOMBRE' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Pais'  where RDB$FIELD_NAME = 'PAIS' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Nacional'  where RDB$FIELD_NAME = 'NACIONAL' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de operacion'  where RDB$FIELD_NAME = 'TIPOOP' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave SAE'  where RDB$FIELD_NAME = 'CLAVESAE' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta  gastos'  where RDB$FIELD_NAME = 'CUENTAGAS' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es un monto'  where RDB$FIELD_NAME = 'ESMONTO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONPORC' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Iva default'  where RDB$FIELD_NAME = 'IVADEFAULT' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de iva'  where RDB$FIELD_NAME = 'PORCENTAJEIVA' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Porcentaje de ISR'  where RDB$FIELD_NAME = 'PORCENTAJEISR' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si incluye iva '  where RDB$FIELD_NAME = 'INCLUYEIVA' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'indica si es proveedor'  where RDB$FIELD_NAME = 'ESPROV' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta bancaria'  where RDB$FIELD_NAME = 'CTABANCARIA' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco'  where RDB$FIELD_NAME = 'BANCO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Forma de pago'  where RDB$FIELD_NAME = 'FRMPAGO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Banco extranjero'  where RDB$FIELD_NAME = 'BANCOEXTRANJERO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identifica si es un RFC extranjero'  where RDB$FIELD_NAME = 'ESIDFISCAL' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Plantilla polDinamica'  where RDB$FIELD_NAME = 'PLANTILLAPOLDIN' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'esta en lista negra 1=si,0=no'  where RDB$FIELD_NAME = 'ESRFCLISTANEGRA' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta al cliente que pertenece el RFC'  where RDB$FIELD_NAME = 'CUENTACLIENTE' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contable que se utiliza para generación masiva cuando el tercero es un proveedor'  where RDB$FIELD_NAME = 'CUENTAPROVEEDORMASIVO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contable que se utiliza para generación masiva cuando el tercero es un cliente'  where RDB$FIELD_NAME = 'CUENTACLIENTEMASIVO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contable que se utiliza para generación masiva cuando se requiera resolver la etiqueta CTAFLUJOCOMUN y sea un cobro'  where RDB$FIELD_NAME = 'CUENTABANCOCOBRO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta contable que se utiliza para generación masiva cuando se requiera resolver la etiqueta CTAFLUJOCOMUN y sea un pago'  where RDB$FIELD_NAME = 'CUENTABANCOPAGO' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Valores posibles: 1=NA, 2=Norte, 3=Sur'  where RDB$FIELD_NAME = 'ZONAFRONTERIZA' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ambito para terceros extranjeros'  where RDB$FIELD_NAME = 'JURISDICCION' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Identifica al sistema del que proviene el tercero (COI, SAE)'  where RDB$FIELD_NAME = 'ORIGEN' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Estado EFOS del tercero'  where RDB$FIELD_NAME = 'SITUACIONEFOS' and RDB$RELATION_NAME = 'RFCTER';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial'  where RDB$FIELD_NAME = 'INICIAL' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial extranjero'  where RDB$FIELD_NAME = 'INICIALEX' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 1'  where RDB$FIELD_NAME = 'CARGO01' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 1'  where RDB$FIELD_NAME = 'ABONO01' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 1'  where RDB$FIELD_NAME = 'CARGOEX01' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 1'  where RDB$FIELD_NAME = 'ABONOEX01' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 2'  where RDB$FIELD_NAME = 'CARGO02' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 2'  where RDB$FIELD_NAME = 'ABONO02' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 2'  where RDB$FIELD_NAME = 'CARGOEX02' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 2'  where RDB$FIELD_NAME = 'ABONOEX02' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 3'  where RDB$FIELD_NAME = 'CARGO03' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 3'  where RDB$FIELD_NAME = 'ABONO03' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 3'  where RDB$FIELD_NAME = 'CARGOEX03' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 3'  where RDB$FIELD_NAME = 'ABONOEX03' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 4'  where RDB$FIELD_NAME = 'CARGO04' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 4'  where RDB$FIELD_NAME = 'ABONO04' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 4'  where RDB$FIELD_NAME = 'CARGOEX04' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 4'  where RDB$FIELD_NAME = 'ABONOEX04' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 5'  where RDB$FIELD_NAME = 'CARGO05' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 5'  where RDB$FIELD_NAME = 'ABONO05' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 5'  where RDB$FIELD_NAME = 'CARGOEX05' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 5'  where RDB$FIELD_NAME = 'ABONOEX05' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 6'  where RDB$FIELD_NAME = 'CARGO06' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 6'  where RDB$FIELD_NAME = 'ABONO06' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 6'  where RDB$FIELD_NAME = 'CARGOEX06' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 6'  where RDB$FIELD_NAME = 'ABONOEX06' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 7'  where RDB$FIELD_NAME = 'CARGO07' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 7'  where RDB$FIELD_NAME = 'ABONO07' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 7'  where RDB$FIELD_NAME = 'CARGOEX07' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 7'  where RDB$FIELD_NAME = 'ABONOEX07' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 8'  where RDB$FIELD_NAME = 'CARGO08' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 8'  where RDB$FIELD_NAME = 'ABONO08' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 8'  where RDB$FIELD_NAME = 'CARGOEX08' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 8'  where RDB$FIELD_NAME = 'ABONOEX08' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 9'  where RDB$FIELD_NAME = 'CARGO09' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 9'  where RDB$FIELD_NAME = 'ABONO09' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 9'  where RDB$FIELD_NAME = 'CARGOEX09' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 9'  where RDB$FIELD_NAME = 'ABONOEX09' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 10'  where RDB$FIELD_NAME = 'CARGO10' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 10'  where RDB$FIELD_NAME = 'ABONO10' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 10'  where RDB$FIELD_NAME = 'CARGOEX10' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 10'  where RDB$FIELD_NAME = 'ABONOEX10' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 11'  where RDB$FIELD_NAME = 'CARGO11' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 11'  where RDB$FIELD_NAME = 'ABONO11' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 11'  where RDB$FIELD_NAME = 'CARGOEX11' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 11'  where RDB$FIELD_NAME = 'ABONOEX11' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 12'  where RDB$FIELD_NAME = 'CARGO12' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 12'  where RDB$FIELD_NAME = 'ABONO12' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 12'  where RDB$FIELD_NAME = 'CARGOEX12' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 12'  where RDB$FIELD_NAME = 'ABONOEX12' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 13'  where RDB$FIELD_NAME = 'CARGO13' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 13'  where RDB$FIELD_NAME = 'ABONO13' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 13'  where RDB$FIELD_NAME = 'CARGOEX13' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 13'  where RDB$FIELD_NAME = 'ABONOEX13' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 14'  where RDB$FIELD_NAME = 'CARGO14' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 14'  where RDB$FIELD_NAME = 'ABONO14' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 14'  where RDB$FIELD_NAME = 'CARGOEX14' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 14'  where RDB$FIELD_NAME = 'ABONOEX14' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 1'  where RDB$FIELD_NAME = 'MOV01' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 2'  where RDB$FIELD_NAME = 'MOV02' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 3'  where RDB$FIELD_NAME = 'MOV03' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 4'  where RDB$FIELD_NAME = 'MOV04' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 5'  where RDB$FIELD_NAME = 'MOV05' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 6'  where RDB$FIELD_NAME = 'MOV06' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 7'  where RDB$FIELD_NAME = 'MOV07' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 8'  where RDB$FIELD_NAME = 'MOV08' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 9'  where RDB$FIELD_NAME = 'MOV09' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 10'  where RDB$FIELD_NAME = 'MOV10' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 11'  where RDB$FIELD_NAME = 'MOV11' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 12'  where RDB$FIELD_NAME = 'MOV12' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 13'  where RDB$FIELD_NAME = 'MOV13' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 14'  where RDB$FIELD_NAME = 'MOV14' and RDB$RELATION_NAME = 'SALDOS24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial'  where RDB$FIELD_NAME = 'INICIAL' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial extranjero'  where RDB$FIELD_NAME = 'INICIALEX' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 1'  where RDB$FIELD_NAME = 'CARGO01' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 1'  where RDB$FIELD_NAME = 'ABONO01' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 1'  where RDB$FIELD_NAME = 'CARGOEX01' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 1'  where RDB$FIELD_NAME = 'ABONOEX01' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 2'  where RDB$FIELD_NAME = 'CARGO02' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 2'  where RDB$FIELD_NAME = 'ABONO02' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 2'  where RDB$FIELD_NAME = 'CARGOEX02' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 2'  where RDB$FIELD_NAME = 'ABONOEX02' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 3'  where RDB$FIELD_NAME = 'CARGO03' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 3'  where RDB$FIELD_NAME = 'ABONO03' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 3'  where RDB$FIELD_NAME = 'CARGOEX03' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 3'  where RDB$FIELD_NAME = 'ABONOEX03' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 4'  where RDB$FIELD_NAME = 'CARGO04' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 4'  where RDB$FIELD_NAME = 'ABONO04' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 4'  where RDB$FIELD_NAME = 'CARGOEX04' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 4'  where RDB$FIELD_NAME = 'ABONOEX04' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 5'  where RDB$FIELD_NAME = 'CARGO05' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 5'  where RDB$FIELD_NAME = 'ABONO05' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 5'  where RDB$FIELD_NAME = 'CARGOEX05' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 5'  where RDB$FIELD_NAME = 'ABONOEX05' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 6'  where RDB$FIELD_NAME = 'CARGO06' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 6'  where RDB$FIELD_NAME = 'ABONO06' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 6'  where RDB$FIELD_NAME = 'CARGOEX06' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 6'  where RDB$FIELD_NAME = 'ABONOEX06' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 7'  where RDB$FIELD_NAME = 'CARGO07' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 7'  where RDB$FIELD_NAME = 'ABONO07' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 7'  where RDB$FIELD_NAME = 'CARGOEX07' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 7'  where RDB$FIELD_NAME = 'ABONOEX07' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 8'  where RDB$FIELD_NAME = 'CARGO08' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 8'  where RDB$FIELD_NAME = 'ABONO08' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 8'  where RDB$FIELD_NAME = 'CARGOEX08' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 8'  where RDB$FIELD_NAME = 'ABONOEX08' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 9'  where RDB$FIELD_NAME = 'CARGO09' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 9'  where RDB$FIELD_NAME = 'ABONO09' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 9'  where RDB$FIELD_NAME = 'CARGOEX09' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 9'  where RDB$FIELD_NAME = 'ABONOEX09' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 10'  where RDB$FIELD_NAME = 'CARGO10' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 10'  where RDB$FIELD_NAME = 'ABONO10' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 10'  where RDB$FIELD_NAME = 'CARGOEX10' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 10'  where RDB$FIELD_NAME = 'ABONOEX10' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 11'  where RDB$FIELD_NAME = 'CARGO11' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 11'  where RDB$FIELD_NAME = 'ABONO11' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 11'  where RDB$FIELD_NAME = 'CARGOEX11' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 11'  where RDB$FIELD_NAME = 'ABONOEX11' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 12'  where RDB$FIELD_NAME = 'CARGO12' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 12'  where RDB$FIELD_NAME = 'ABONO12' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 12'  where RDB$FIELD_NAME = 'CARGOEX12' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 12'  where RDB$FIELD_NAME = 'ABONOEX12' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 13'  where RDB$FIELD_NAME = 'CARGO13' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 13'  where RDB$FIELD_NAME = 'ABONO13' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 13'  where RDB$FIELD_NAME = 'CARGOEX13' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 13'  where RDB$FIELD_NAME = 'ABONOEX13' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 14'  where RDB$FIELD_NAME = 'CARGO14' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 14'  where RDB$FIELD_NAME = 'ABONO14' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 14'  where RDB$FIELD_NAME = 'CARGOEX14' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para extranjero para el mes 14'  where RDB$FIELD_NAME = 'ABONOEX14' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 1'  where RDB$FIELD_NAME = 'MOV01' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 2'  where RDB$FIELD_NAME = 'MOV02' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 3'  where RDB$FIELD_NAME = 'MOV03' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 4'  where RDB$FIELD_NAME = 'MOV04' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 5'  where RDB$FIELD_NAME = 'MOV05' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 6'  where RDB$FIELD_NAME = 'MOV06' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 7'  where RDB$FIELD_NAME = 'MOV07' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 8'  where RDB$FIELD_NAME = 'MOV08' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 9'  where RDB$FIELD_NAME = 'MOV09' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 10'  where RDB$FIELD_NAME = 'MOV10' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 11'  where RDB$FIELD_NAME = 'MOV11' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 12'  where RDB$FIELD_NAME = 'MOV12' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 13'  where RDB$FIELD_NAME = 'MOV13' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 14'  where RDB$FIELD_NAME = 'MOV14' and RDB$RELATION_NAME = 'SALDOS25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Departamento'  where RDB$FIELD_NAME = 'DEPTO' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo incial'  where RDB$FIELD_NAME = 'INICIAL' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial extranjero'  where RDB$FIELD_NAME = 'INICIALEX' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 1'  where RDB$FIELD_NAME = 'CARGO01' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 1'  where RDB$FIELD_NAME = 'ABONO01' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 1'  where RDB$FIELD_NAME = 'CARGOEX01' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 1'  where RDB$FIELD_NAME = 'ABONOEX01' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 2'  where RDB$FIELD_NAME = 'CARGO02' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 2'  where RDB$FIELD_NAME = 'ABONO02' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 2'  where RDB$FIELD_NAME = 'CARGOEX02' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 2'  where RDB$FIELD_NAME = 'ABONOEX02' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 3'  where RDB$FIELD_NAME = 'CARGO03' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 3'  where RDB$FIELD_NAME = 'ABONO03' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 3'  where RDB$FIELD_NAME = 'CARGOEX03' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 3'  where RDB$FIELD_NAME = 'ABONOEX03' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 4'  where RDB$FIELD_NAME = 'CARGO04' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 4'  where RDB$FIELD_NAME = 'ABONO04' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 4'  where RDB$FIELD_NAME = 'CARGOEX04' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 4'  where RDB$FIELD_NAME = 'ABONOEX04' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 5'  where RDB$FIELD_NAME = 'CARGO05' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 5'  where RDB$FIELD_NAME = 'ABONO05' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 5'  where RDB$FIELD_NAME = 'CARGOEX05' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 5'  where RDB$FIELD_NAME = 'ABONOEX05' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 6'  where RDB$FIELD_NAME = 'CARGO06' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 6'  where RDB$FIELD_NAME = 'ABONO06' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 6'  where RDB$FIELD_NAME = 'CARGOEX06' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 6'  where RDB$FIELD_NAME = 'ABONOEX06' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 7'  where RDB$FIELD_NAME = 'CARGO07' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 7'  where RDB$FIELD_NAME = 'ABONO07' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 7'  where RDB$FIELD_NAME = 'CARGOEX07' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 7'  where RDB$FIELD_NAME = 'ABONOEX07' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 8'  where RDB$FIELD_NAME = 'CARGO08' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 8'  where RDB$FIELD_NAME = 'ABONO08' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 8'  where RDB$FIELD_NAME = 'CARGOEX08' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 8'  where RDB$FIELD_NAME = 'ABONOEX08' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 9'  where RDB$FIELD_NAME = 'CARGO09' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 9'  where RDB$FIELD_NAME = 'ABONO09' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 9'  where RDB$FIELD_NAME = 'CARGOEX09' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 9'  where RDB$FIELD_NAME = 'ABONOEX09' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 10'  where RDB$FIELD_NAME = 'CARGO10' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 10'  where RDB$FIELD_NAME = 'ABONO10' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 10'  where RDB$FIELD_NAME = 'CARGOEX10' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 10'  where RDB$FIELD_NAME = 'ABONOEX10' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 11'  where RDB$FIELD_NAME = 'CARGO11' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 11'  where RDB$FIELD_NAME = 'ABONO11' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 11'  where RDB$FIELD_NAME = 'CARGOEX11' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 11'  where RDB$FIELD_NAME = 'ABONOEX11' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 12'  where RDB$FIELD_NAME = 'CARGO12' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 12'  where RDB$FIELD_NAME = 'ABONO12' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 12'  where RDB$FIELD_NAME = 'CARGOEX12' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 12'  where RDB$FIELD_NAME = 'ABONOEX12' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 13'  where RDB$FIELD_NAME = 'CARGO13' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 13'  where RDB$FIELD_NAME = 'ABONO13' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 13'  where RDB$FIELD_NAME = 'CARGOEX13' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 13'  where RDB$FIELD_NAME = 'ABONOEX13' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 14'  where RDB$FIELD_NAME = 'CARGO14' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 14'  where RDB$FIELD_NAME = 'ABONO14' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 14'  where RDB$FIELD_NAME = 'CARGOEX14' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 14'  where RDB$FIELD_NAME = 'ABONOEX14' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 1'  where RDB$FIELD_NAME = 'MOV01' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 2'  where RDB$FIELD_NAME = 'MOV02' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 3'  where RDB$FIELD_NAME = 'MOV03' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 4'  where RDB$FIELD_NAME = 'MOV04' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 5'  where RDB$FIELD_NAME = 'MOV05' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 6'  where RDB$FIELD_NAME = 'MOV06' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 7'  where RDB$FIELD_NAME = 'MOV07' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 8'  where RDB$FIELD_NAME = 'MOV08' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 9'  where RDB$FIELD_NAME = 'MOV09' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 10'  where RDB$FIELD_NAME = 'MOV10' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 11'  where RDB$FIELD_NAME = 'MOV11' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 12'  where RDB$FIELD_NAME = 'MOV12' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 13'  where RDB$FIELD_NAME = 'MOV13' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 14'  where RDB$FIELD_NAME = 'MOV14' and RDB$RELATION_NAME = 'SALDOSDP24';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de cuenta'  where RDB$FIELD_NAME = 'NUM_CTA' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Ejercicio'  where RDB$FIELD_NAME = 'EJERCICIO' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Departamento'  where RDB$FIELD_NAME = 'DEPTO' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo incial'  where RDB$FIELD_NAME = 'INICIAL' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Saldo inicial extranjero'  where RDB$FIELD_NAME = 'INICIALEX' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 1'  where RDB$FIELD_NAME = 'CARGO01' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 1'  where RDB$FIELD_NAME = 'ABONO01' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 1'  where RDB$FIELD_NAME = 'CARGOEX01' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 1'  where RDB$FIELD_NAME = 'ABONOEX01' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 2'  where RDB$FIELD_NAME = 'CARGO02' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 2'  where RDB$FIELD_NAME = 'ABONO02' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 2'  where RDB$FIELD_NAME = 'CARGOEX02' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 2'  where RDB$FIELD_NAME = 'ABONOEX02' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 3'  where RDB$FIELD_NAME = 'CARGO03' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 3'  where RDB$FIELD_NAME = 'ABONO03' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 3'  where RDB$FIELD_NAME = 'CARGOEX03' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 3'  where RDB$FIELD_NAME = 'ABONOEX03' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 4'  where RDB$FIELD_NAME = 'CARGO04' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 4'  where RDB$FIELD_NAME = 'ABONO04' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 4'  where RDB$FIELD_NAME = 'CARGOEX04' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 4'  where RDB$FIELD_NAME = 'ABONOEX04' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 5'  where RDB$FIELD_NAME = 'CARGO05' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 5'  where RDB$FIELD_NAME = 'ABONO05' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 5'  where RDB$FIELD_NAME = 'CARGOEX05' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 5'  where RDB$FIELD_NAME = 'ABONOEX05' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 6'  where RDB$FIELD_NAME = 'CARGO06' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 6'  where RDB$FIELD_NAME = 'ABONO06' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 6'  where RDB$FIELD_NAME = 'CARGOEX06' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 6'  where RDB$FIELD_NAME = 'ABONOEX06' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 7'  where RDB$FIELD_NAME = 'CARGO07' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 7'  where RDB$FIELD_NAME = 'ABONO07' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 7'  where RDB$FIELD_NAME = 'CARGOEX07' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 7'  where RDB$FIELD_NAME = 'ABONOEX07' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 8'  where RDB$FIELD_NAME = 'CARGO08' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 8'  where RDB$FIELD_NAME = 'ABONO08' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 8'  where RDB$FIELD_NAME = 'CARGOEX08' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 8'  where RDB$FIELD_NAME = 'ABONOEX08' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 9'  where RDB$FIELD_NAME = 'CARGO09' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 9'  where RDB$FIELD_NAME = 'ABONO09' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 9'  where RDB$FIELD_NAME = 'CARGOEX09' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 9'  where RDB$FIELD_NAME = 'ABONOEX09' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 10'  where RDB$FIELD_NAME = 'CARGO10' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 10'  where RDB$FIELD_NAME = 'ABONO10' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 10'  where RDB$FIELD_NAME = 'CARGOEX10' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 10'  where RDB$FIELD_NAME = 'ABONOEX10' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 11'  where RDB$FIELD_NAME = 'CARGO11' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 11'  where RDB$FIELD_NAME = 'ABONO11' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 11'  where RDB$FIELD_NAME = 'CARGOEX11' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 11'  where RDB$FIELD_NAME = 'ABONOEX11' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 12'  where RDB$FIELD_NAME = 'CARGO12' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 12'  where RDB$FIELD_NAME = 'ABONO12' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 12'  where RDB$FIELD_NAME = 'CARGOEX12' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 12'  where RDB$FIELD_NAME = 'ABONOEX12' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 13'  where RDB$FIELD_NAME = 'CARGO13' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 13'  where RDB$FIELD_NAME = 'ABONO13' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 13'  where RDB$FIELD_NAME = 'CARGOEX13' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 13'  where RDB$FIELD_NAME = 'ABONOEX13' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo para el mes 14'  where RDB$FIELD_NAME = 'CARGO14' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono para el mes 14'  where RDB$FIELD_NAME = 'ABONO14' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cargo extranjero para el mes 14'  where RDB$FIELD_NAME = 'CARGOEX14' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Abono extranjero para el mes 14'  where RDB$FIELD_NAME = 'ABONOEX14' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 1'  where RDB$FIELD_NAME = 'MOV01' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 2'  where RDB$FIELD_NAME = 'MOV02' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 3'  where RDB$FIELD_NAME = 'MOV03' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 4'  where RDB$FIELD_NAME = 'MOV04' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 5'  where RDB$FIELD_NAME = 'MOV05' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 6'  where RDB$FIELD_NAME = 'MOV06' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 7'  where RDB$FIELD_NAME = 'MOV07' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 8'  where RDB$FIELD_NAME = 'MOV08' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 9'  where RDB$FIELD_NAME = 'MOV09' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 10'  where RDB$FIELD_NAME = 'MOV10' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 11'  where RDB$FIELD_NAME = 'MOV11' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 12'  where RDB$FIELD_NAME = 'MOV12' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 13'  where RDB$FIELD_NAME = 'MOV13' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Movimiento para el mes 14'  where RDB$FIELD_NAME = 'MOV14' and RDB$RELATION_NAME = 'SALDOSDP25';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clave'  where RDB$FIELD_NAME = 'CLAVE' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Deduccion normal'  where RDB$FIELD_NAME = 'DEDNORMAL' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo deducible'  where RDB$FIELD_NAME = 'DEDIMED' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Maximo deducible'  where RDB$FIELD_NAME = 'MAXDED' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Metodo de depreciacion'  where RDB$FIELD_NAME = 'METODODEP' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = ' Porcentaje de Depreciacion proyectada'  where RDB$FIELD_NAME = 'DEPPROY' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta del activo'  where RDB$FIELD_NAME = 'CTAAACTV' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta del depreciacion del activo'  where RDB$FIELD_NAME = 'CTADEPRE' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de gastos'  where RDB$FIELD_NAME = 'CTAGASTOS' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Cuenta de ganancias'  where RDB$FIELD_NAME = 'CTAPERGAN' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Moneda'  where RDB$FIELD_NAME = 'QUEMONEDA' and RDB$RELATION_NAME = 'TIPACTIV';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo'  where RDB$FIELD_NAME = 'TIPO' and RDB$RELATION_NAME = 'TIPOSPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Descripcion'  where RDB$FIELD_NAME = 'DESCRIP' and RDB$RELATION_NAME = 'TIPOSPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Clasificacion fiscal'  where RDB$FIELD_NAME = 'CLASSAT' and RDB$RELATION_NAME = 'TIPOSPOL';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Numero de registro'  where RDB$FIELD_NAME = 'NUMREG' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'UUID del  comprobante'  where RDB$FIELD_NAME = 'UUIDTIMBRE' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Monto'  where RDB$FIELD_NAME = 'MONTO' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Serie'  where RDB$FIELD_NAME = 'SERIE' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Folio'  where RDB$FIELD_NAME = 'FOLIO' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC emisor'  where RDB$FIELD_NAME = 'RFCEMISOR' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'RFC receptor'  where RDB$FIELD_NAME = 'RFCRECEPTOR' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Orden de la partida'  where RDB$FIELD_NAME = 'ORDEN' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Fecha'  where RDB$FIELD_NAME = 'FECHA' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Indica si es CFDi o Extranjero'  where RDB$FIELD_NAME = 'TIPOCOMPROBANTE' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'tipo de cambio'  where RDB$FIELD_NAME = 'TIPOCAMBIO' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'version del CFDI'  where RDB$FIELD_NAME = 'VERSIONCFDI' and RDB$RELATION_NAME = 'UUIDTIMBRES';
UPDATE RDB$RELATION_FIELDS set RDB$DESCRIPTION = 'Tipo de moneda'  where RDB$FIELD_NAME = 'MONEDA' and RDB$RELATION_NAME = 'UUIDTIMBRES';
GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ACTIVOS24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ACTIVOS25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ADMPER TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON AUXILIAR24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON AUXILIAR25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CCOSTOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CGRUPOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON COMPLEMENTOSPAGOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CONCEPTO TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CONTROL TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CTAING TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CTANIF TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CTARUB TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CTAS_PRODSERV TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CTATER TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CUENTAS24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON CUENTAS25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DEPTOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DESIET TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DIARIOSAE TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DOCTOSAE TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DOCTOSFISCALES TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON DOCTOSRELPAGOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON EDOFINNIFS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ETIQ_CCOSTOS_SIGO TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ETIQ_CTAS_POLDINAMICA TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ETIQ_CTAS_SIGO TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON ETIQ_OPERACION_SIGO TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON FOLIOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON HISTOR TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON HOJAS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON IMPUESTOSFISCALES TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON INFADIPAR TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON INFOSAE TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON INPC TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON LISTANEGRARFC TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON MONEDAS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON NIFS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON OPEIET TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON OPETER TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON OTROSIMPUESTOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON OTROSIMPUESTOSING TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PAGO TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PARAMEMP TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PARAMGEN TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PLANTILLAXRFC TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON POLDINAMICA TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON POLIZAS24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON POLIZAS25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PRESUP24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PRESUP25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PRESUPDP24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON PRESUPDP25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON RANGOS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON REGPOL TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON RFCTER TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON SALDOS24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON SALDOS25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON SALDOSDP24 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON SALDOSDP25 TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON TIPACTIV TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON TIPOSPOL TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON UUIDTIMBRES TO  SYSDBA WITH GRANT OPTION;

