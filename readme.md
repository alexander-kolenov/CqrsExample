
# CQRS example

> I wrote this code as ugly as possible.\
> But, I am trying to use all principles of onion architecture.

So the **challenge** is to fix all the architectural problems.\
Use the `MediatR` library,\
to make it extremely SQRS-able.

> In this branch I made a wrong way to solve this challenge!

## Db initialization script

```sql
CREATE TABLE region (
  id serial PRIMARY KEY,
  name TEXT NOT NULL
);

CREATE TABLE weather (
  id serial PRIMARY KEY,
  temperature float8,
  region_id INTEGER REFERENCES region (id)
);
```
