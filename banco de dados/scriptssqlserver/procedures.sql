Create Procedure ExcluirTarefaPorId
(
	@id int
)

as

begin
	Delete From tarefas where id = @id
end

Create Procedure AtualizarTarefa
(
	@id int,
	@nome nvarchar(100),
	@dataCadastro date,
	@dataLimite date
)

as

begin

Update tarefas set nome = @nome,
dataCadastro = @dataCadastro,
dataLimite = @dataLimite
where id = @id
end

Create Procedure IncluirTarefa
(
	@nome nvarchar(100),
	@dataCadastro date,
	@dataLimite date
)

as

begin

Insert INTO tarefas ( nome, dataCadastro, dataLimite)
values
(@nome,@dataCadastro,@dataLimite)
end

Create Procedure SelecionarTarefaPorId
(
	@id int
)

as

begin

Select * from tarefas where id = @id
end

Create Procedure SelecionarTarefas

as

begin

Select id,nome, dataCadastro, dataLimite from tarefas
order by dataCadastro

end

Create Procedure SelecionarTarefaPorData
(
	@dataLimite date
)

as

begin

Select id, nome, dataCadastro, dataLimite from tarefas where dataLimite = @dataLimite
order by dataLimite desc;

end




