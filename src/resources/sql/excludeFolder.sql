delete from files
 where path like @path || '%'
   and list_id = @list_id