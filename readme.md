
# CQRS example

> I wrote this code as ugly as possible.\
> But trying to use all principles of onion architecture.

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
