<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="54c014c3-adb1-4f60-b4b4-bb190942aa39" namespace="CurrencyStore.Collector.Configration" xmlSchemaNamespace="urn:CurrencyStore.Collector.Configration" assemblyName="CurrencyStore.Collector.Configration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="CurrencyStoreSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="currency.Store">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Server" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="server" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/ServerElement" />
          </type>
        </elementProperty>
        <elementProperty name="Task" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="task" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/TaskElement" />
          </type>
        </elementProperty>
        <elementProperty name="Authorization" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="authorization" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/AuthorizationElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="ServerElement">
      <attributeProperties>
        <attributeProperty name="Port" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="port" isReadOnly="false" defaultValue="8234">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Backlog" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="backlog" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Instrumentation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="instrumentation" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Buffer" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="buffer" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/BufferElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="BufferElement">
      <attributeProperties>
        <attributeProperty name="MaxLength" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="maxLength" isReadOnly="false" defaultValue="4000">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Size" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="size" isReadOnly="false" defaultValue="1024">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="TaskElement">
      <attributeProperties>
        <attributeProperty name="PoolSize" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="poolSize" isReadOnly="false" documentation="每次处理数据" defaultValue="50">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Interval" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="interval" isReadOnly="false" defaultValue="500">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Timeout" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="timeout" isReadOnly="false" defaultValue="1000">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Capacity" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="capacity" isReadOnly="false" defaultValue="5">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Storage" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="storage" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/StorageSection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="AuthorizationElement">
      <attributeProperties>
        <attributeProperty name="AllowAnonymous" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="allowAnonymous" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="StorageSection">
      <attributeProperties>
        <attributeProperty name="Type" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Enable" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enable" isReadOnly="false" defaultValue="&quot;true&quot;">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="Value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/54c014c3-adb1-4f60-b4b4-bb190942aa39/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>