# cartera-api Specification

## Purpose

Exposes a client's accounts-receivable (cartera) - the list of pending documents owed by a given third party - sourced from its stored procedure, so client applications can support collections and follow-up workflows.

## Requirements

### Requirement: Cartera endpoint accepting a client NIT
The system SHALL expose `GET /cartera/{nitCli}`, where `nitCli` is a route parameter, sourced from `usr_itq_Read_carteraId` called with its `@nit_cli` parameter (varchar(15)) set to the route value. As currently implemented by the stored procedure, `@nit_cli` does not filter the result: the endpoint returns the same full accounts-receivable list regardless of the `nitCli` value supplied. The route parameter is kept so the contract does not need to change if the stored procedure is later updated to filter by it.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /cartera/{nitCli}` with any `nitCli` value
- **THEN** the API responds with HTTP 200 and a JSON array of the full accounts-receivable list returned by the stored procedure

### Requirement: Cartera document field mapping
Each returned document SHALL remap every field from the stored procedure's source names to camelCase: `cod_cli`→`codigoCliente`, `nit_cli`→`nitCliente`, `ano_doc`→`anoDocumento`, `per_doc`→`periodoDocumento`, `tip_doc`→`tipoDocumento`, `sub_tip`→`subTipoDocumento`, `num_doc`→`numeroDocumento`, `reg_doc`→`registroDocumento`, `det_doc`→`detalleDocumento`, `fec_ven`→`fechaVencimiento`, `cod_suc`→`codigoSucursal`, `cod_cco`→`codigoCentroCosto`, `cod_cl1`→`codigoClasificador1`, `cod_cl2`→`codigoClasificador2`, `cod_cl3`→`codigoClasificador3`, `ind_con`→`indicadorConciliacion`, `sal_doc`→`saldoDocumento`, `val_ret`→`valorRetencion`, `val_ica`→`valorIca`, `ret_iva`→`retencionIva`, `may_val`→`mayorValor`, `men_val`→`menorValor`, `valorPago`→`valorPago` (unchanged), `cod_cta`→`codigoCuentaContable`, `tip_mon`→`tipoMoneda`, `cod_pai`→`codigoPais`, `cod_dep`→`codigoDepartamento`, `cod_ciu`→`codigoCiudad`.

#### Scenario: All fields remapped to camelCase
- **WHEN** a cartera document is returned
- **THEN** every one of its 27 fields appears under its camelCase name rather than the stored procedure's source name

### Requirement: Empty cartera handling
When the stored procedure returns no rows, the system SHALL respond with HTTP 200 and an empty JSON array rather than an error.

#### Scenario: Stored procedure returns no rows
- **WHEN** the stored procedure call succeeds but returns no rows
- **THEN** the endpoint responds with HTTP 200 and `[]`

### Requirement: Upstream failure handling
The system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed cartera list when the stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to the cartera stored procedure throws an error
- **THEN** the endpoint responds with an HTTP 5xx status and no cartera data
