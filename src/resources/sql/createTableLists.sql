create table if not exists lists(
    id integer primary key autoincrement not null,
    name text unique not null)