using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login200D
{
    /// <summary>
    /// The valid App states.
    /// </summary>
    public enum State
    {
        NOTINIT = -1,
        START = 0,
        GOTUSERNAME,
        GOTPASSWORD,
        SUCCESS,
        DECLINED,
        EXIT
    }

    public class ControllerD
    {
        private StateObs observer;

        public void registerObs(StateObs obs)
        {
            this.observer = obs;
        }

        /// <summary>
        /// The App's DB
        /// </summary>
        CredentialD model;

        /// <summary>
        /// The App's user interaction
        /// </summary>
        Login200D view;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="v"></param>
        public ControllerD(CredentialD m)
        {
            model = m;
            //view = v;
        }

        /// <summary>
        /// Based on the state the controller will act and apply
        /// the logic needed to process the information. After taking action,
        /// it will notify the view of the result.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        public void handleEvents(State state, String args)
        {
            switch (state)
            {
                case State.START:

                    observer(State.START);
                    break;
                case State.GOTUSERNAME:
                    observer(State.GOTUSERNAME);
                    break;
                case State.GOTPASSWORD:
                    observer(State.GOTPASSWORD);
                    bool valid = validateCredentials(args);
                    if (valid)
                    {
                        observer(State.SUCCESS);
                    }
                    else
                    {
                        observer(State.DECLINED);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Process the credential following the preestablished format and
        /// using the information stored in the DB, validates if the user is 
        /// allowed to log in.
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        private bool validateCredentials(String cred)
        {
            bool result = false;
            String[] tokens = cred.Split(':');
            String un = tokens[0];
            String up = tokens[1];

            result = model.Validate(un, up);
            return result;
        }
    }
}
