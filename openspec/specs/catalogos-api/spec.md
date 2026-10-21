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
