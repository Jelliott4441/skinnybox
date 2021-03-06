/*
 * Copyright (c) Citrix Systems, Inc. 
 *
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 *   1) Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 * 
 *   2) Redistributions in binary form must reproduce the above
 *      copyright notice, this list of conditions and the following
 *      disclaimer in the documentation and/or other materials
 *      provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
 * COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections;
using System.Collections.Generic;

using CookComputing.XmlRpc;


namespace XenAPI
{
    public partial class Host_metrics : XenObject<Host_metrics>
    {
        public Host_metrics()
        {
        }

        public Host_metrics(string uuid,
            long memory_total,
            long memory_free,
            bool live,
            DateTime last_updated,
            Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.memory_total = memory_total;
            this.memory_free = memory_free;
            this.live = live;
            this.last_updated = last_updated;
            this.other_config = other_config;
        }

        /// <summary>
        /// Creates a new Host_metrics from a Proxy_Host_metrics.
        /// </summary>
        /// <param name="proxy"></param>
        public Host_metrics(Proxy_Host_metrics proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public override void UpdateFrom(Host_metrics update)
        {
            uuid = update.uuid;
            memory_total = update.memory_total;
            memory_free = update.memory_free;
            live = update.live;
            last_updated = update.last_updated;
            other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_Host_metrics proxy)
        {
            uuid = proxy.uuid == null ? null : (string)proxy.uuid;
            memory_total = proxy.memory_total == null ? 0 : long.Parse((string)proxy.memory_total);
            memory_free = proxy.memory_free == null ? 0 : long.Parse((string)proxy.memory_free);
            live = (bool)proxy.live;
            last_updated = proxy.last_updated;
            other_config = proxy.other_config == null ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public Proxy_Host_metrics ToProxy()
        {
            Proxy_Host_metrics result_ = new Proxy_Host_metrics();
            result_.uuid = (uuid != null) ? uuid : "";
            result_.memory_total = memory_total.ToString();
            result_.memory_free = memory_free.ToString();
            result_.live = live;
            result_.last_updated = last_updated;
            result_.other_config = Maps.convert_to_proxy_string_string(other_config);
            return result_;
        }

        /// <summary>
        /// Creates a new Host_metrics from a Hashtable.
        /// </summary>
        /// <param name="table"></param>
        public Host_metrics(Hashtable table)
        {
            uuid = Marshalling.ParseString(table, "uuid");
            memory_total = Marshalling.ParseLong(table, "memory_total");
            memory_free = Marshalling.ParseLong(table, "memory_free");
            live = Marshalling.ParseBool(table, "live");
            last_updated = Marshalling.ParseDateTime(table, "last_updated");
            other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public bool DeepEquals(Host_metrics other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Helper.AreEqual2(this._uuid, other._uuid) &&
                Helper.AreEqual2(this._memory_total, other._memory_total) &&
                Helper.AreEqual2(this._memory_free, other._memory_free) &&
                Helper.AreEqual2(this._live, other._live) &&
                Helper.AreEqual2(this._last_updated, other._last_updated) &&
                Helper.AreEqual2(this._other_config, other._other_config);
        }

        public override string SaveChanges(Session session, string opaqueRef, Host_metrics server)
        {
            if (opaqueRef == null)
            {
                System.Diagnostics.Debug.Assert(false, "Cannot create instances of this type on the server");
                return "";
            }
            else
            {
                if (!Helper.AreEqual2(_other_config, server._other_config))
                {
                    Host_metrics.set_other_config(session, opaqueRef, _other_config);
                }

                return null;
            }
        }

        public static Host_metrics get_record(Session session, string _host_metrics)
        {
            return new Host_metrics((Proxy_Host_metrics)session.proxy.host_metrics_get_record(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse());
        }

        public static XenRef<Host_metrics> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Host_metrics>.Create(session.proxy.host_metrics_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static string get_uuid(Session session, string _host_metrics)
        {
            return (string)session.proxy.host_metrics_get_uuid(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse();
        }

        public static long get_memory_total(Session session, string _host_metrics)
        {
            return long.Parse((string)session.proxy.host_metrics_get_memory_total(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse());
        }

        public static long get_memory_free(Session session, string _host_metrics)
        {
            return long.Parse((string)session.proxy.host_metrics_get_memory_free(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse());
        }

        public static bool get_live(Session session, string _host_metrics)
        {
            return (bool)session.proxy.host_metrics_get_live(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse();
        }

        public static DateTime get_last_updated(Session session, string _host_metrics)
        {
            return session.proxy.host_metrics_get_last_updated(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _host_metrics)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.host_metrics_get_other_config(session.uuid, (_host_metrics != null) ? _host_metrics : "").parse());
        }

        public static void set_other_config(Session session, string _host_metrics, Dictionary<string, string> _other_config)
        {
            session.proxy.host_metrics_set_other_config(session.uuid, (_host_metrics != null) ? _host_metrics : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void add_to_other_config(Session session, string _host_metrics, string _key, string _value)
        {
            session.proxy.host_metrics_add_to_other_config(session.uuid, (_host_metrics != null) ? _host_metrics : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void remove_from_other_config(Session session, string _host_metrics, string _key)
        {
            session.proxy.host_metrics_remove_from_other_config(session.uuid, (_host_metrics != null) ? _host_metrics : "", (_key != null) ? _key : "").parse();
        }

        public static List<XenRef<Host_metrics>> get_all(Session session)
        {
            return XenRef<Host_metrics>.Create(session.proxy.host_metrics_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Host_metrics>, Host_metrics> get_all_records(Session session)
        {
            return XenRef<Host_metrics>.Create<Proxy_Host_metrics>(session.proxy.host_metrics_get_all_records(session.uuid).parse());
        }

        private string _uuid;
        public string uuid {
             get { return _uuid; }
             set { if (!Helper.AreEqual(value, _uuid)) { _uuid = value; Changed = true; NotifyPropertyChanged("uuid"); } }
         }	

        private long _memory_total;
        public long memory_total {
             get { return _memory_total; }
             set { if (!Helper.AreEqual(value, _memory_total)) { _memory_total = value; Changed = true; NotifyPropertyChanged("memory_total"); } }
         }	

        private long _memory_free;
        public long memory_free {
             get { return _memory_free; }
             set { if (!Helper.AreEqual(value, _memory_free)) { _memory_free = value; Changed = true; NotifyPropertyChanged("memory_free"); } }
         }	

        private bool _live;
        public bool live {
             get { return _live; }
             set { if (!Helper.AreEqual(value, _live)) { _live = value; Changed = true; NotifyPropertyChanged("live"); } }
         }	

        private DateTime _last_updated;
        public DateTime last_updated {
             get { return _last_updated; }
             set { if (!Helper.AreEqual(value, _last_updated)) { _last_updated = value; Changed = true; NotifyPropertyChanged("last_updated"); } }
         }	

        private Dictionary<string, string> _other_config;
        public Dictionary<string, string> other_config {
             get { return _other_config; }
             set { if (!Helper.AreEqual(value, _other_config)) { _other_config = value; Changed = true; NotifyPropertyChanged("other_config"); } }
         }	


    }
}
