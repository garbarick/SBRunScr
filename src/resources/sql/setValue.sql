insert into settings (name, value)
values (@name, @value)
on conflict(name) do update set value = excluded.value