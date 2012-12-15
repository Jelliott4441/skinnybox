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
    public partial class Blob : XenObject<Blob>
    {
        public Blob()
        {
        }

        public Blob(string uuid,
            string name_label,
            string name_description,
            long size,
            bool pubblic,
            DateTime last_updated,
            string mime_type)
        {
            this.uuid = uuid;
            this.name_label = name_label;
            this.name_description = name_description;
            this.size = size;
            this.pubblic = pubblic;
            this.last_updated = last_updated;
            this.mime_type = mime_type;
        }

        /// <summary>
        /// Creates a new Blob from a Proxy_Blob.
        /// </summary>
        /// <param name="proxy"></param>
        public Blob(Proxy_Blob proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public override void UpdateFrom(Blob update)
        {
            uuid = update.uuid;
            name_label = update.name_label;
            name_description = update.name_description;
            size = update.size;
            pubblic = update.pubblic;
            last_updated = update.last_updated;
            mime_type = update.mime_type;
        }

        internal void UpdateFromProxy(Proxy_Blob proxy)
        {
            uuid = proxy.uuid == null ? null : (string)proxy.uuid;
            name_label = proxy.name_label == null ? null : (string)proxy.name_label;
            name_description = proxy.name_description == null ? null : (string)proxy.name_description;
            size = proxy.size == null ? 0 : long.Parse((string)proxy.size);
            pubblic = (bool)proxy.pubblic;
            last_updated = proxy.last_updated;
            mime_type = proxy.mime_type == null ? null : (string)proxy.mime_type;
        }

        public Proxy_Blob ToProxy()
        {
            Proxy_Blob result_ = new Proxy_Blob();
            result_.uuid = (uuid != null) ? uuid : "";
            result_.name_label = (name_label != null) ? name_label : "";
            result_.name_description = (name_description != null) ? name_description : "";
            result_.size = size.ToString();
            result_.pubblic = pubblic;
            result_.last_updated = last_updated;
            result_.mime_type = (mime_type != null) ? mime_type : "";
            return result_;
        }

        /// <summary>
        /// Creates a new Blob from a Hashtable.
        /// </summary>
        /// <param name="table"></param>
        public Blob(Hashtable table)
        {
            uuid = Marshalling.ParseString(table, "uuid");
            name_label = Marshalling.ParseString(table, "name_label");
            name_description = Marshalling.ParseString(table, "name_description");
            size = Marshalling.ParseLong(table, "size");
            pubblic = Marshalling.ParseBool(table, "pubblic");
            last_updated = Marshalling.ParseDateTime(table, "last_updated");
            mime_type = Marshalling.ParseString(table, "mime_type");
        }

        public bool DeepEquals(Blob other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Helper.AreEqual2(this._uuid, other._uuid) &&
                Helper.AreEqual2(this._name_label, other._name_label) &&
                Helper.AreEqual2(this._name_description, other._name_description) &&
                Helper.AreEqual2(this._size, other._size) &&
                Helper.AreEqual2(this._pubblic, other._pubblic) &&
                Helper.AreEqual2(this._last_updated, other._last_updated) &&
                Helper.AreEqual2(this._mime_type, other._mime_type);
        }

        public override string SaveChanges(Session session, string opaqueRef, Blob server)
        {
            if (opaqueRef == null)
            {
                System.Diagnostics.Debug.Assert(false, "Cannot create instances of this type on the server");
                return "";
            }
            else
            {
                if (!Helper.AreEqual2(_name_label, server._name_label))
                {
                    Blob.set_name_label(session, opaqueRef, _name_label);
                }
                if (!Helper.AreEqual2(_name_description, server._name_description))
                {
                    Blob.set_name_description(session, opaqueRef, _name_description);
                }

                return null;
            }
        }

        public static Blob get_record(Session session, string _blob)
        {
            return new Blob((Proxy_Blob)session.proxy.blob_get_record(session.uuid, (_blob != null) ? _blob : "").parse());
        }

        public static XenRef<Blob> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<Blob>.Create(session.proxy.blob_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static List<XenRef<Blob>> get_by_name_label(Session session, string _label)
        {
            return XenRef<Blob>.Create(session.proxy.blob_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        public static string get_uuid(Session session, string _blob)
        {
            return (string)session.proxy.blob_get_uuid(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static string get_name_label(Session session, string _blob)
        {
            return (string)session.proxy.blob_get_name_label(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static string get_name_description(Session session, string _blob)
        {
            return (string)session.proxy.blob_get_name_description(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static long get_size(Session session, string _blob)
        {
            return long.Parse((string)session.proxy.blob_get_size(session.uuid, (_blob != null) ? _blob : "").parse());
        }

        public static bool get_public(Session session, string _blob)
        {
            return (bool)session.proxy.blob_get_public(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static DateTime get_last_updated(Session session, string _blob)
        {
            return session.proxy.blob_get_last_updated(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static string get_mime_type(Session session, string _blob)
        {
            return (string)session.proxy.blob_get_mime_type(session.uuid, (_blob != null) ? _blob : "").parse();
        }

        public static void set_name_label(Session session, string _blob, string _label)
        {
            session.proxy.blob_set_name_label(session.uuid, (_blob != null) ? _blob : "", (_label != null) ? _label : "").parse();
        }

        public static void set_name_description(Session session, string _blob, string _description)
        {
            session.proxy.blob_set_name_description(session.uuid, (_blob != null) ? _blob : "", (_description != null) ? _description : "").parse();
        }

        public static void set_public(Session session, string _blob, bool _public)
        {
            session.proxy.blob_set_public(session.uuid, (_blob != null) ? _blob : "", _public).parse();
        }

        public static XenRef<Blob> create(Session session, string _mime_type, bool _public)
        {
            return XenRef<Blob>.Create(session.proxy.blob_create(session.uuid, (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        public static void destroy(Session session, string _self)
        {
            session.proxy.blob_destroy(session.uuid, (_self != null) ? _self : "").parse();
        }

        public static List<XenRef<Blob>> get_all(Session session)
        {
            return XenRef<Blob>.Create(session.proxy.blob_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<Blob>, Blob> get_all_records(Session session)
        {
            return XenRef<Blob>.Create<Proxy_Blob>(session.proxy.blob_get_all_records(session.uuid).parse());
        }

        private string _uuid;
        public string uuid {
             get { return _uuid; }
             set { if (!Helper.AreEqual(value, _uuid)) { _uuid = value; Changed = true; NotifyPropertyChanged("uuid"); } }
         }	

        private string _name_label;
        public string name_label {
             get { return _name_label; }
             set { if (!Helper.AreEqual(value, _name_label)) { _name_label = value; Changed = true; NotifyPropertyChanged("name_label"); } }
         }	

        private string _name_description;
        public string name_description {
             get { return _name_description; }
             set { if (!Helper.AreEqual(value, _name_description)) { _name_description = value; Changed = true; NotifyPropertyChanged("name_description"); } }
         }	

        private long _size;
        public long size {
             get { return _size; }
             set { if (!Helper.AreEqual(value, _size)) { _size = value; Changed = true; NotifyPropertyChanged("size"); } }
         }	

        private bool _pubblic;
        public bool pubblic {
             get { return _pubblic; }
             set { if (!Helper.AreEqual(value, _pubblic)) { _pubblic = value; Changed = true; NotifyPropertyChanged("pubblic"); } }
         }	

        private DateTime _last_updated;
        public DateTime last_updated {
             get { return _last_updated; }
             set { if (!Helper.AreEqual(value, _last_updated)) { _last_updated = value; Changed = true; NotifyPropertyChanged("last_updated"); } }
         }	

        private string _mime_type;
        public string mime_type {
             get { return _mime_type; }
             set { if (!Helper.AreEqual(value, _mime_type)) { _mime_type = value; Changed = true; NotifyPropertyChanged("mime_type"); } }
         }	


    }
}
