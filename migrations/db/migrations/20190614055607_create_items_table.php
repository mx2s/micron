<?php


use Phinx\Migration\AbstractMigration;

class CreateItemsTable extends AbstractMigration
{
    public function change()
    {
        $table = $this->table('items');
        $table
            ->addColumn('title', 'string')
            ->addColumn('guid', 'string')
            ->addColumn('price', 'decimal', [
                'default' => 0,
                'scale' => 2
            ])
            ->addIndex(['guid'], ['unique' => true])
            ->create();
    }
}
