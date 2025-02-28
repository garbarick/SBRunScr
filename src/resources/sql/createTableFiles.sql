create table if not exists files(
    id integer primary key autoincrement not null,
    path text not null,
    list_id integer,
    foreign key (list_id) references lists(id) on delete cascade)