# catalogos-api Specification

## Purpose

Exposes read-only reference catalogs (third parties, chart-of-accounts, document subtypes) sourced from their respective stored procedures, so client applications can populate lookup/search controls.

## Requirements

### Requirement: Terceros catalog endpoint
The system SHALL expose `GET /catalogos/terceros`, requiring no query parameters, that returns the full third-party catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_tercerosId` called with its `@ter_nit` parameter set to `null`, mapping `ter_nit` to `codigo` and `ter_nombre` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/terceros`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` (the third party's NIT) and `nombre` (their name)

### Requirement: Cuentas contables catalog endpoint
The system SHALL expose `GET /catalogos/cuentas-contables`, requiring no query parameters, that returns the full chart-of-accounts catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_cuentasContablesId` called with its `@cod_cta` parameter set to `null`, mapping `cod_cta` to `codigo` and `nom_cta` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/cuentas-contables`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` (the account code) and `nombre` (the account name)

### Requirement: SubTipos documento catalog endpoint
The system SHALL expose `GET /catalogos/subtipos-documento`, requiring no query parameters, that returns the full document-subtype catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_subTiposDocId` called with its `@cod_sub` parameter set to `null`, mapping `cod_sub` to `codigo` and `nom_sub` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/subtipos-documento`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` (the subtype code) and `nombre` (the subtype name)

### Requirement: Empty catalog handling
For any of the three catalog endpoints, when the underlying stored procedure returns no rows, the system SHALL respond with HTTP 200 and an empty JSON array rather than an error.

#### Scenario: Stored procedure returns no rows
- **WHEN** a catalog's stored procedure call succeeds but returns no rows
- **THEN** the corresponding endpoint responds with HTTP 200 and `[]`

### Requirement: Upstream failure handling
For any of the three catalog endpoints, the system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed catalog when its stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to a catalog's stored procedure throws an error
- **THEN** the corresponding endpoint responds with an HTTP 5xx status and no catalog data

### Requirement: Sucursales catalog endpoint
The system SHALL expose `GET /catalogos/sucursales`, requiring no query parameters, that returns the full sucursales catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_sucursalId` called with its `@cod_suc` parameter set to `null`, mapping `cod_suc` to `codigo` and `nom_suc` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/sucursales`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` (the sucursal code) and `nombre` (the sucursal name)

### Requirement: Centros de costo catalog endpoint
The system SHALL expose `GET /catalogos/centros-costo`, requiring no query parameters, that returns the full centros-de-costo catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_cCostoId` called with its `@cod_cco` parameter set to `null`, mapping `cod_cco` to `codigo` and `nom_cco` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/centros-costo`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` (the cost center code) and `nombre` (the cost center name)

### Requirement: Ciudades catalog endpoint
The system SHALL expose `GET /catalogos/ciudades`, requiring no query parameters, that returns the full ciudades catalog as a JSON array of `{ codigo, nombre, codigoDepartamento, codigoPais }` objects, sourced from `usr_itq_Read_ciudadId` called with its `@cod_ciu` parameter set to `null`, mapping `cod_ciu` to `codigo`, `nom_ciu` to `nombre`, `cod_dep` to `codigoDepartamento`, and `cod_pai` to `codigoPais`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/ciudades`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo`, `nombre`, `codigoDepartamento`, and `codigoPais`

### Requirement: Clasificador1 catalog endpoint
The system SHALL expose `GET /catalogos/clasificador1`, requiring no query parameters, that returns the full clasificador1 catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_clasif1Id` called with its `@cod_cl1` parameter set to `null`, mapping `cod_cl1` to `codigo` and `nom_cl1` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/clasificador1`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` and `nombre`

### Requirement: Clasificador2 catalog endpoint
The system SHALL expose `GET /catalogos/clasificador2`, requiring no query parameters, that returns the full clasificador2 catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_clasif2Id` called with its `@cod_cl2` parameter set to `null`, mapping `cod_cl2` to `codigo` and `nom_cl2` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/clasificador2`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` and `nombre`

### Requirement: Clasificador3 catalog endpoint
The system SHALL expose `GET /catalogos/clasificador3`, requiring no query parameters, that returns the full clasificador3 catalog as a JSON array of `{ codigo, nombre }` objects, sourced from `usr_itq_Read_clasif3Id` called with its `@cod_cl3` parameter set to `null`, mapping `cod_cl3` to `codigo` and `nom_cl3` to `nombre`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/clasificador3`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo` and `nombre`

### Requirement: Retenciones catalog endpoint
The system SHALL expose `GET /catalogos/retenciones`, requiring no query parameters, that returns the full retenciones catalog as a JSON array of `{ codigo, nombre, porcentaje, cuentaContable, nombreCuenta }` objects, sourced from `usr_itq_Read_retencionId` called with its `@cod_ret` parameter set to `null`, mapping `cod_ret` to `codigo`, `nombre` to `nombre`, `por_ret` to `porcentaje`, `cta_ret` to `cuentaContable`, and `nom_cta` to `nombreCuenta`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /catalogos/retenciones`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `codigo`, `nombre`, `porcentaje`, `cuentaContable`, and `nombreCuenta`

### Requirement: Empty catalog handling for additional catalogs
For any of the seven additional catalog endpoints (sucursales, centros-costo, ciudades, clasificador1, clasificador2, clasificador3, retenciones), when the underlying stored procedure returns no rows, the system SHALL respond with HTTP 200 and an empty JSON array rather than an error.

#### Scenario: Stored procedure returns no rows
- **WHEN** one of the seven additional catalogs' stored procedure call succeeds but returns no rows
- **THEN** the corresponding endpoint responds with HTTP 200 and `[]`

### Requirement: Upstream failure handling for additional catalogs
For any of the seven additional catalog endpoints, the system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed catalog when its stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to one of the seven additional catalogs' stored procedure throws an error
- **THEN** the corresponding endpoint responds with an HTTP 5xx status and no catalog data
