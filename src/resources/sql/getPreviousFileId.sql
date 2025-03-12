select coalesce(previous, last)
  from (
select p.id,
       p.path,
       p.type,
       p.list_id,
       lag(p.id) over (partition by p.list_id order by path) previous,
       first_value(p.id) over (partition by p.list_id order by path desc) last
  from files p) p,
       settings l,
       settings f
 where l.name = @lastListKey
   and p.list_id = l.value
   and f.name = p.list_id || '.' || @lastFileKey
   and f.value = p.id