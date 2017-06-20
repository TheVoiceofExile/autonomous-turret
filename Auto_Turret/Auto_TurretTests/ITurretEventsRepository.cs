using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqRepository
{
    public interface ITurretEventsRepository
    {
        IList<Turrets_Table> FindAllTurrets();
        IList<Events_Table> FindAllEvents();
        IList<Users_Table> FindAllUsers();
        Users_Table FindByUserID(int user_id);
        Turrets_Table FindByTurretID(int turret_id);
        Events_Table FindByEventID(int event_id);
    }
}
