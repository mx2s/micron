<?php


use Phinx\Migration\AbstractMigration;

class AlterUsersAddGuid extends AbstractMigration
{
    public function change()
    {
    	$table = $this->table('users');
        $table->addColumn('guid', 'char', ['limit' => 36])
            ->update();
    }
}
