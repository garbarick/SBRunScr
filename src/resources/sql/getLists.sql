select id,
       name,
       (select count(*) from files f where f.list_id = l.id) cnt
  from lists l
 order by name