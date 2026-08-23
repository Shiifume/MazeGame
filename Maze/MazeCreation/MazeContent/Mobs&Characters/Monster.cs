using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;

namespace Maze.MazeCreation.MazeContent.Mobs_Characters
{
    internal class Monster : Combattants
    {
        public Monster(char symbol)
        {
            Symbol = symbol;
            Name = Symbol.ToString();
        }


        public override void Visit(Personnage personnage)
        {
            if(this.Strength-personnage.Defense >= personnage.Life)
            {
                throw new MazePlayerDeadException($"{personnage.Name} est mort en combattant le monstre{this.Name}. La partie est perdue !");
            }
            else
            {
                int damageDealt = this.Strength > personnage.Defense ? this.Strength - personnage.Defense : 0;
                personnage.Life -= damageDealt;

                if(personnage.Strength-this.Defense < this.Life)
                {
                    int damageReceived = personnage.Strength > this.Defense ? personnage.Strength - this.Defense : 0;
                    this.Life -= damageReceived;
                    throw new MazeMonsterException($"{personnage.Name} s'est battu contre {this.Name}!\n{personnage.Name} a perdu {damageDealt} pts de vie et a infligé {damageReceived} pts de dégâts");
                }
                else
                {
                    throw new MazeMonsterDiedException($"{personnage.Name} s'est battu contre {this.Name}!\nLe monstre est mort et {personnage.Name} a perdu {damageDealt} pts de vie");
                }
            }


            


        }
    }
}
