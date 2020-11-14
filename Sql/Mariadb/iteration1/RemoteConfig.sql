

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `App`
-- ----------------------------
DROP TABLE IF EXISTS `App`;
CREATE TABLE `App` (
  `AppId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`AppId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;



-- ----------------------------
-- Table structure for `AppComponent`
-- ----------------------------
DROP TABLE IF EXISTS `AppComponent`;
CREATE TABLE `AppComponent` (
  `AppComponentId` int(11) NOT NULL AUTO_INCREMENT,
  `ComponetId` int(11) NOT NULL,
  `ComponentServiceCompeleteName` varchar(1000) DEFAULT NULL,
  `ComponentServiceName` varchar(200) DEFAULT NULL,
  `ComponentAssemblyName` varchar(300) DEFAULT NULL,
  `ComponentAssemblyFileName` varchar(300) NOT NULL,
  `ComponentAssemblyFileStorePath` varchar(1000) DEFAULT NULL,
  `AssemblyVersion` varchar(100) DEFAULT NULL,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`AppComponentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of AppComponent
-- ----------------------------

-- ----------------------------
-- Table structure for `AppComponentInterface`
-- ----------------------------
DROP TABLE IF EXISTS `AppComponentInterface`;
CREATE TABLE `AppComponentInterface` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ComponentInterface` varchar(300) NOT NULL,
  `AppComponentId` int(11) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of AppComponentInterface
-- ----------------------------

-- ----------------------------
-- Table structure for `AppConfig`
-- ----------------------------
DROP TABLE IF EXISTS `AppConfig`;
CREATE TABLE `AppConfig` (
  `AppConfigId` int(11) NOT NULL AUTO_INCREMENT,
  `AppId` int(11) NOT NULL,
  `SolutionID` varchar(1024) NOT NULL,
  `SolutionName` varchar(100) NOT NULL,
  `ConfigContent` longtext NOT NULL,
  `Version` int(11) NOT NULL DEFAULT 0,
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`AppConfigId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of AppConfig
-- ----------------------------

-- ----------------------------
-- Table structure for `AppInstance`
-- ----------------------------
DROP TABLE IF EXISTS `AppInstance`;
CREATE TABLE `AppInstance` (
  `AppInstanceId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(200) NOT NULL,
  `AppId` int(11) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`AppInstanceId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of AppInstance
-- ----------------------------

-- ----------------------------
-- Table structure for `AppUser`
-- ----------------------------
DROP TABLE IF EXISTS `AppUser`;
CREATE TABLE `AppUser` (
  `AppUserId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Title` varchar(50) DEFAULT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`AppUserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of AppUser
-- ----------------------------

-- ----------------------------
-- Table structure for `Component`
-- ----------------------------
DROP TABLE IF EXISTS `Component`;
CREATE TABLE `Component` (
  `ComponentID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`ComponentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Component
-- ----------------------------

-- ----------------------------
-- Table structure for `ComponentConfig`
-- ----------------------------
DROP TABLE IF EXISTS `ComponentConfig`;
CREATE TABLE `ComponentConfig` (
  `ComponentConfigId` int(11) NOT NULL AUTO_INCREMENT,
  `ComponentId` int(11) NOT NULL,
  `Content` longtext NOT NULL,
  `Version` int(11) NOT NULL DEFAULT 1,
  `ComponentConfigTitle` varchar(100) NOT NULL,
  `IsDefault` bit(1) NOT NULL DEFAULT b'0',
  `CreateTime` timestamp NULL DEFAULT current_timestamp(),
  `UpdateTime` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`ComponentConfigId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of ComponentConfig
-- ----------------------------

-- ----------------------------
-- Table structure for `Rel_AppComponent_AppUser`
-- ----------------------------
DROP TABLE IF EXISTS `Rel_AppComponent_AppUser`;
CREATE TABLE `Rel_AppComponent_AppUser` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AppId` int(11) NOT NULL,
  `AppUserId` int(11) NOT NULL,
  `AppComponentId` int(11) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Rel_AppComponent_AppUser
-- ----------------------------

-- ----------------------------
-- Table structure for `Rel_AppConfig_ComponentConfig`
-- ----------------------------
DROP TABLE IF EXISTS `Rel_AppConfig_ComponentConfig`;
CREATE TABLE `Rel_AppConfig_ComponentConfig` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AppConfigId` int(11) NOT NULL,
  `AppConfigVersion` int(11) NOT NULL,
  `SolutionID` varchar(1024) NOT NULL,
  `ComponentConfigId` int(11) NOT NULL,
  `ComponentConfigVersion` int(11) NOT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Rel_AppConfig_ComponentConfig
-- ----------------------------
