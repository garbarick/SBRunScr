select coalesce(next, first)
  from (
select p.id,
       p.path,
       p.type,
       p.list_id,
       first_value(p.id) over (partition by p.list_id order by path) first,
       lead(p.id) over (partition by p.list_id order by path) next
  from files p) p,
       settings l,
       settings f
 where l.name = 'lastList'
   and p.list_id = l.value
   and f.name = p.list_id || '.lastFile'
   and f.value = p.id