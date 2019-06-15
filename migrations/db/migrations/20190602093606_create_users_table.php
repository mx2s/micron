<?php


use Phinx\Migration\AbstractMigration;

class CreateUsersTable extends AbstractMigration
{
    public function change()
    {
        $table = $this->table('users');
        $table
            ->addColumn('login', 'string')
            ->addColumn('password', 'string')
            ->addColumn('email', 'string', ['null' => true])
            ->addColumn('register_date', 'timestamp', ['default' => 'CURRENT_TIMESTAMP'])
            
            ->addIndex(['email'], ['unique' => true])
            ->create();
    }
}
