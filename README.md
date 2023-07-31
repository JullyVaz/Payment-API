# Payment-API

API REST utilizando .Net Core
 API possui 3 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar venda: Busca pelo Id da venda;
  3) Atualizar venda: Permite que seja atualizado o status da venda.
     * OBS.: Possíveis status: 'Pagamento aprovado' | 'Enviado para transportadora' | 'Entregue' | 'Cancelada'.
- A venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
- O vendedor possui Id, cpf, nome, e-mail e telefone;
- A inclusão de uma venda possui pelo menos 1 item;
- A atualização de status permiti somente as seguintes transições: 
  - De: 'Aguardando pagamento' Para: 'Pagamento Aprovado'
  - De: 'Aguardando pagamento' Para: 'Cancelada'
  - De: 'Pagamento Aprovado' Para: 'Enviado para Transportadora'
  - De: 'Pagamento Aprovado' Para: 'Cancelada'
  - De: 'Enviado para Transportador'. Para: 'Entregue'
- A API não tem mecanismos de autenticação/autorização.


