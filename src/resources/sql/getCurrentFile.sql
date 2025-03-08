select p.path
  from settings l,
       settings f,
       files p
 where l.name = 'lastList'
   and f.name = l.value || '.lastFile'
   and p.id = f.value