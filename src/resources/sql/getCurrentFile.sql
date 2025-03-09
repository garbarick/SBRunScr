select p.id,
       p.path,
       p.type
  from settings l,
       settings f,
       files p
 where l.name = 'lastList'
   and f.name = l.value || '.lastFile'
   and p.list_id = l.value
   and p.id = f.value