delete
from TB_IBT_XML_ItemPedido_itp
where ped_Pedido_int_FK not in (select ped_Pedido_int_PK from tb_ibt_xml_pedido_ped)