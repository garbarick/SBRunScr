create table if not exists files(
    id integer primary key autoincrement not null,
    path text unique not null,
    type integer not null default 0,
    list_id integer,
    foreign key (list_id) references lists(id) on delete cascade)