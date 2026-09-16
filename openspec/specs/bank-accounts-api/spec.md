# bank-accounts-api Specification

## Purpose

Exposes an HTTP endpoint that returns the accounts belonging to a given bank, sourced from the `usr_itq_Read_cuentasbancosId` stored procedure, so client applications can populate an account selector filtered by bank.

## Requirements

### Requirement: List accounts by bank endpoint
The system SHALL expose `GET /banks/{bankId}/accounts`, where `bankId` is a required route parameter, that returns the accounts for that bank as a JSON array of objects with `id`, `bankId`, `name`, `accountNumber`, and `tipoCuenta`.

#### Scenario: Successful retrieval with accounts
- **WHEN** a client sends `GET /banks/{bankId}/accounts` for a bank that has accounts
- **THEN** the API responds with HTTP 200 and a JSON array of that bank's accounts

#### Scenario: Bank has no accounts
- **WHEN** a client sends `GET /banks/{bankId}/accounts` for a bank whose accounts are `null` or absent from the stored procedure's result
- **THEN** the API responds with HTTP 200 and an empty JSON array

### Requirement: Accounts sourced from stored procedure, filtered by requested bank
The system SHALL obtain the account list by executing `usr_itq_Read_cuentasbancosId` with the requested `bankId` as its input parameter, parsing the single JSON-text result column (`cuentasBancos`) into per-bank entries, and returning only the accounts belonging to the entry whose `cod_ban` equals the requested `bankId`.

#### Scenario: Mapping stored procedure output
- **WHEN** the stored procedure's result contains an entry with `cod_ban` equal to the requested `bankId` and a non-null nested account list
- **THEN** each nested account is mapped to `id` = `ctabanco`, `name` = `nombre`, `accountNumber` = `ctabanco`, `bankId` = the requested `bankId` (not the nested entry's own `bancos` field), and `tipoCuenta` = `tipoCuenta`

### Requirement: Upstream failure handling
The system SHALL return an HTTP 5xx error and SHALL NOT return a partial or malformed account list when the stored procedure call fails or its result cannot be parsed.

#### Scenario: Stored procedure call fails
- **WHEN** the database call to `usr_itq_Read_cuentasbancosId` throws an error
- **THEN** the API responds with an HTTP 5xx status and no account data
