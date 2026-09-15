# bank-catalog-api Specification

## Purpose

Exposes an HTTP endpoint that returns the catalog of banks, sourced from the `usr_itq_Read_bancosId` stored procedure, so client applications can populate a bank selector.

## Requirements

### Requirement: List banks endpoint
The system SHALL expose `GET /banks`, requiring no query parameters, that returns the full bank catalog as a JSON array of objects with an `id` and a `name`.

#### Scenario: Successful retrieval
- **WHEN** a client sends `GET /banks`
- **THEN** the API responds with HTTP 200 and a JSON array where each item has `id` (the bank code) and `name` (the bank's display name)

#### Scenario: Empty catalog
- **WHEN** the underlying data source returns no banks
- **THEN** the API responds with HTTP 200 and an empty JSON array

### Requirement: Bank catalog sourced from stored procedure
The system SHALL obtain the bank catalog by executing the `usr_itq_Read_bancosId` stored procedure and parsing its single JSON-text result column into individual bank records, mapping each record's `cod_ban` to `id` and `nom_ban` to `name`.

#### Scenario: Mapping stored procedure output
- **WHEN** the stored procedure returns a JSON array with entries containing `cod_ban` and `nom_ban`
- **THEN** each entry is mapped to a bank with `id` equal to `cod_ban` and `name` equal to `nom_ban`

### Requirement: Upstream failure handling
The system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed bank list when the stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to `usr_itq_Read_bancosId` throws an error
- **THEN** the API responds with an HTTP 5xx status and no bank data
