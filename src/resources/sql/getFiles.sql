select id, path, type
  from files
 where list_id = @list_id
 order by path