# extracto-movements-api Specification

## Purpose

Exposes an HTTP endpoint that returns the movement rows of a previously loaded bank statement extract, sourced from the `usr_itq_Read_ExtractoId` stored procedure, so client applications can populate a movements table.

## Requirements

### Requirement: Get extract movements endpoint
The system SHALL expose `GET /extractos/{idExtracto}`, where `idExtracto` is a required route parameter, that returns the extract's movements as a JSON array.

#### Scenario: Successful retrieval with movements
- **WHEN** a client sends `GET /extractos/{idExtracto}` for an extract that has movements
- **THEN** the API responds with HTTP 200 and a JSON array of that extract's movement rows

#### Scenario: Extract has no movements
- **WHEN** a client sends `GET /extractos/{idExtracto}` for an extract whose movements are absent from the stored procedure's result
- **THEN** the API responds with HTTP 200 and an empty JSON array

### Requirement: Movements sourced from stored procedure
The system SHALL obtain the movement list by executing `usr_itq_Read_ExtractoId` with the requested `idExtracto` as its `bigint` input parameter, and parsing the single JSON-text result column (`bancos`) into movement records with the same fields the stored procedure returns: `idRegistroExtracto`, `idExtracto`, `fechaMovimiento`, `descripcionMovimiento`, `detalleMovimiento`, `debito`, `credito`, `nitTercero`, `nombreTercero`, `tipoMovimiento`, `subTipoDocumento`, `cuentaContable`.

#### Scenario: Mapping stored procedure output
- **WHEN** the stored procedure returns a JSON array of movement objects
- **THEN** each object is mapped to a movement record with the same field values, unchanged

### Requirement: Upstream failure handling
The system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed movement list when the stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to `usr_itq_Read_ExtractoId` throws an error
- **THEN** the API responds with an HTTP 5xx status and no movement data
