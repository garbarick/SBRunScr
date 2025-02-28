create table if not exists settings(
    id integer primary key autoincrement not null,
    name text not null,
    value text)