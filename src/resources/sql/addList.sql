insert into lists(name) values(@name);
select last_insert_rowid();