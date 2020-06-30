# Interest Calculator

## About:

- DDD
- CQRS
- Microservices Architecture
- Tests
- .NET 3.1 : WebApis
- .NET Standard : Classs Libraries

## APIs

### RateAPI

return current rate

### InterestCalculatorAPI

the calculator requests rate from RateAPI, calculates interest and return total value as text with 2 decimal places. 

## How to run

enter command: `docker-compose up -d`

Path: *src/docker-compose.yaml*

open: http://localhost:5003/swagger/index.html