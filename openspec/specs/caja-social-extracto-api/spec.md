# caja-social-extracto-api Specification

## Purpose

Exposes an HTTP endpoint that loads a Banco Caja Social bank statement extract (as a JSON document built by the frontend) into the database via the `usr_sp_itq_CargaExtractoCajaSocial` stored procedure, and returns the generated extract identifier.

## Requirements

### Requirement: Load Caja Social extract endpoint
The system SHALL expose `POST /extractos/caja-social`, accepting the request body as the extract JSON document, and SHALL return the generated extract identifier on success.

#### Scenario: Successful load
- **WHEN** a client sends `POST /extractos/caja-social` with a valid extract JSON body
- **THEN** the API responds with an HTTP success status and a body containing the generated `idExtracto`

### Requirement: Extract JSON forwarded unchanged to the stored procedure
The system SHALL forward the request body's JSON text, unmodified, as the `@cajaSocial` input parameter of `usr_sp_itq_CargaExtractoCajaSocial`, without deserializing it into an intermediate typed model.

#### Scenario: Request body passed as-is
- **WHEN** the request body is a JSON document
- **THEN** the exact JSON text received is what is sent as `@cajaSocial` to the stored procedure, with no field remapping or reserialization

### Requirement: Generated extract ID returned from the stored procedure's output parameter
The system SHALL read the stored procedure's `@idExtracto` output parameter after execution and return its value as the endpoint's result.

#### Scenario: idExtracto returned to the caller
- **WHEN** the stored procedure completes and sets `@idExtracto`
- **THEN** the endpoint's response includes that value

### Requirement: Upstream failure handling
The system SHALL return an HTTP 5xx error and SHALL NOT return a success response or a fabricated extract ID when the stored procedure call fails.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to `usr_sp_itq_CargaExtractoCajaSocial` throws an error
- **THEN** the API responds with an HTTP 5xx status and no extract ID
